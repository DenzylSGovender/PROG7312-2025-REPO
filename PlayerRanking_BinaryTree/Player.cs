using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerRanking_BinaryTree
{
    public class Player
    {
        public string Name { get; set; }
        public int Ranking { get; set; }
        public int Points { get; set; }

        public override string ToString()
        {
            return $"Ranking: {Ranking}, Name: {Name}, Points: {Points}";
        }
    }
}
