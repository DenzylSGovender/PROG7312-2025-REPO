using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerRanking_BinaryTree
{
    public class BinarySearchTree
    {
        private TreeNode root;

        public void Insert(Player player)
        {
            root = InsertRec(root, player);
        }

        private TreeNode InsertRec(TreeNode node, Player player)
        {
            if (node == null) return new TreeNode(player);

            if (player.Ranking < node.Data.Ranking)
                node.Left = InsertRec(node.Left, player);
            else if (player.Ranking > node.Data.Ranking)
                node.Right = InsertRec(node.Right, player);

            return node;
        }

        public Player Search(int ranking)
        {
            return SearchRec(root, ranking)?.Data;
        }

        private TreeNode SearchRec(TreeNode node, int ranking)
        {
            if (node == null || node.Data.Ranking == ranking)
                return node;

            if (ranking < node.Data.Ranking)
                return SearchRec(node.Left, ranking);

            return SearchRec(node.Right, ranking);
        }

        public List<Player> InOrderTraversal()
        {
            List<Player> players = new List<Player>();
            InOrderRec(root, players);
            return players;
        }

        private void InOrderRec(TreeNode node, List<Player> players)
        {
            if (node != null)
            {
                InOrderRec(node.Left, players);
                players.Add(node.Data);
                InOrderRec(node.Right, players);
            }
        }
    }
}
