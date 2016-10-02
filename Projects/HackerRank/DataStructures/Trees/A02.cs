using System;
using Common;
using Common.DataStructures.Trees;

namespace HackerRank.DataStructures.Trees
{
    //Tree: Postorder Traversal
    //https://www.hackerrank.com/challenges/tree-postorder-traversal
    class A02 : IProgram
    {
        public void Run(string[] args)
        {
            Node head = global::Common.DataStructures.Trees.TreeBuilder.Parse("3(5(1,4),2(6))");
            PostOrder(head);
        }

        private void PostOrder(Node current)
        {
            if (current == null)
            {
                return;
            }

            PostOrder(current.Left);
            PostOrder(current.Right);
            Console.Write(current.Data + " ");
        }
    }
}
