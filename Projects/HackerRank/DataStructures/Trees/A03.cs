using System;
using Common;
using Common.DataStructures.Trees;

namespace HackerRank.DataStructures.Trees
{
    //Tree: Inorder Traversal
    //https://www.hackerrank.com/challenges/tree-inorder-traversal
    class A03: IProgram
    {
        public void Run(string[] args)
        {
		    Node root = global::Common.DataStructures.Trees.Trees.Parse("3(5(1,4),2(6))");
		    InOrder(root);
        }

        public void InOrder(Node current)
        {
            if (current == null)
            {
                return;
            }

            InOrder(current.Left);
            Console.Write(current.Data + " ");
            InOrder(current.Right);
        }

    }
}
