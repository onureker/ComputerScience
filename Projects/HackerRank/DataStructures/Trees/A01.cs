using System;
using Common;
using Common.DataStructures.Trees;

namespace HackerRank.DataStructures.Trees
{
    //Tree: Preorder Traversal
    //https://www.hackerrank.com/challenges/tree-preorder-traversal
    class A01 : IProgram
    {
        public void Run(string[] args)
        {
            Node head = global::Common.DataStructures.Trees.Trees.Parse("3(5(1,4),2(6))");
            PreOrder(head);
        }

        private void PreOrder(Node current)
        {
            if (current == null)
            {
                return;
            }

            Console.Write(current.Data + " ");
            PreOrder(current.Left);
            PreOrder(current.Right);
        }
    }
}
