using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PlayerRanking_BinaryTree
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private BinarySearchTree bst = new BinarySearchTree();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtRanking.Text, out int ranking) ||
              !int.TryParse(txtPoints.Text, out int points))
            {
                txtStatus.Text = "Please enter valid numbers for Ranking and Points.";
                return;
            }

            var player = new Player
            {
                Name = txtName.Text,
                Ranking = ranking,
                Points = points
            };

            bst.Insert(player);
            txtStatus.Text = $" Player {player.Name} added!";
            UpdatePlayerList();
        }

        private void SearchPlayer_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtSearchRanking.Text, out int searchRanking))
            {
                txtStatus.Text = "Please enter a valid number for search.";
                return;
            }

            var player = bst.Search(searchRanking);
            if (player != null)
            {
                txtStatus.Text = $" Found: {player}";
            }
            else
            {
                txtStatus.Text = " Player not found.";
            }
        }

        private void UpdatePlayerList()
        {
            lstPlayers.Items.Clear();
            foreach (var p in bst.InOrderTraversal())
            {
                lstPlayers.Items.Add(p.ToString());
            }
        }

    }
}