using System;
using System.Windows;
using System.Windows.Controls;

namespace RestaurantTree
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();   
            InitializeMenu();
        }

        // Setup initial menu
        private void InitializeMenu()
        {
            var root = new TreeViewItem() { Header = "Menu", IsExpanded = true };
            MenuTree.Items.Add(root);

            var starters = new TreeViewItem() { Header = "Starters" };
            starters.Items.Add(new TreeViewItem() { Header = "Mushroom Soup" });
            starters.Items.Add(new TreeViewItem() { Header = "Garlic Bread" });

            var mains = new TreeViewItem() { Header = "Mains" };
            mains.Items.Add(new TreeViewItem() { Header = "Steak" });
            mains.Items.Add(new TreeViewItem() { Header = "Veggie Burger" });

            var desserts = new TreeViewItem() { Header = "Desserts" };
            desserts.Items.Add(new TreeViewItem() { Header = "Chocolate Cake" });
            desserts.Items.Add(new TreeViewItem() { Header = "Ice Cream" });

            root.Items.Add(starters);
            root.Items.Add(mains);
            root.Items.Add(desserts);
        }

        // Add item under selected node
        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            string newName = txtItemName.Text?.Trim();
            if (string.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show("Enter a name for the new item or category.");
                return;
            }

            // MenuTree.SelectedItem will be the TreeViewItem we added earlier,
            // because we are inserting TreeViewItem objects directly.
            if (MenuTree.SelectedItem is TreeViewItem selected)
            {
                selected.Items.Add(new TreeViewItem() { Header = newName });
                selected.IsExpanded = true;
                txtItemName.Clear();
            }
            else
            {
                MessageBox.Show("Please select a parent node in the tree to add under.");
            }
        }

        // Search for an item in the tree
        private void SearchItem_Click(object sender, RoutedEventArgs e)
        {
            string searchText = txtSearch.Text?.Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Enter text to search for.");
                return;
            }

            foreach (var obj in MenuTree.Items)
            {
                if (obj is TreeViewItem root)
                {
                    TreeViewItem found = FindItem(root, searchText);
                    if (found != null)
                    {
                        // expand parents while finding (see FindItem implementation)
                        found.IsSelected = true;
                        found.BringIntoView();
                        MessageBox.Show($"Found: {found.Header}");
                        return;
                    }
                }
            }

            MessageBox.Show("Item not found.");
        }

        // Recursive search in TreeView that also expands parent nodes when a match is found deeper down
        private TreeViewItem FindItem(TreeViewItem parent, string searchText)
        {
            if (parent == null) return null;

            if (string.Equals(parent.Header?.ToString(), searchText, StringComparison.OrdinalIgnoreCase))
                return parent;

            foreach (var obj in parent.Items)
            {
                if (obj is TreeViewItem child)
                {
                    var found = FindItem(child, searchText);
                    if (found != null)
                    {
                        // expand this parent so the found child is visible
                        parent.IsExpanded = true;
                        return found;
                    }
                }
            }

            return null;
        }
    }
}
