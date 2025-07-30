using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinkedListExample
{
    public class LinkedList
    {
        private Node head;// Keeps track of the first node in the list.

        // Add a node at the end of the list
        public void Add(int data)
        {
            Node newNode = new Node(data);//create an instance with the given data

            if (head == null)//if list is empty, set head to the new node
            {
                head = newNode;
            }
            else//If the list is not empty then add
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        // Print all nodes in the list
        public void PrintList()
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }

        // Delete a node by value
        public void Delete(int data)
        {
            if (head == null) return;// If the list is empty, there's nothing to delete.

            if (head.Data == data)// Check if the Node to Delete is the Head Node:
            {
                head = head.Next;// Update head to the next node in the list.
                return;// Exit the method as the node has been deleted.
            }

            // Traverse the List to Find the Node to Delete:
            Node current = head;
            while (current.Next != null && current.Next.Data != data)
            {
                current = current.Next;// Move to the next node.
            }
            // Delete the Node by Updating the Links:
            if (current.Next != null)
            {
                current.Next = current.Next.Next;// Bypass the node to be deleted.
            }
        }

        // Search for a node by value
        public bool Search(int data)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data == data)
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }
    }

}
