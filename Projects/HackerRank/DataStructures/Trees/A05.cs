using System;
using Common;
using Common.DataStructures.Trees;

namespace HackerRank.DataStructures.Trees
{
    //Tree : Top View
    //https://www.hackerrank.com/challenges/tree-top-view
    class A05: IProgram
    {
        public void Run(string[] args)
        {
            Node root = global::Common.DataStructures.Trees.Trees.Parse("3(5(1(,9),4),2(6,7(8)))");
            TopView(root);
        }

        private void TopView(Node root)
        {
            TopViewLeft(root.Left);
            Console.Write(root.Data + " ");
            TopViewRight(root.Right);
        }

        private void TopViewLeft(Node root)
        {
            if (root == null)
            {
                return;
            }

            TopViewLeft(root.Left);
            Console.Write(root.Data + " ");
        }

        private void TopViewRight(Node root)
        {
            if (root == null)
            {
                return;
            }

            Console.Write(root.Data + " ");
            TopViewRight(root.Right);
        }
    }
}
