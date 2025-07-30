using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            Console.WriteLine("Initial List:");
            list.PrintList();

            Console.WriteLine("Delete 2:");
            list.Delete(2);
            list.PrintList();

            Console.WriteLine("Search for 3:");
            bool found = list.Search(3);
            Console.WriteLine(found ? "Found" : "Not Found");
            Console.ReadKey();
        }
    }
}
