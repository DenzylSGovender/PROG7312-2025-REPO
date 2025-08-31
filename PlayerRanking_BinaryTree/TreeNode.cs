using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerRanking_BinaryTree
{
    public class TreeNode
    {
        public Player Data { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(Player data)
        {
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }
    }
}
