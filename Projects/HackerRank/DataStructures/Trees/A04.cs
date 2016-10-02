using System;
using Common;
using Common.DataStructures.Trees;

namespace HackerRank.DataStructures.Trees
{
    //Tree: Height of a Binary Tree
    //https://www.hackerrank.com/challenges/tree-height-of-a-binary-tree
    class A04 : IProgram
    {
        public void Run(string[] args)
        {
            TreeNode root = global::Common.DataStructures.Trees.Trees.Parse("3(2(1),5(4,6(7)))");
            int height = FindHeight(root);
            Console.WriteLine(height);
        }

        private int FindHeight(TreeNode current)
        {
            if (current == null)
            {
                return -1;
            }

            int leftHeight = FindHeight(current.Left);
            int rightHeight = FindHeight(current.Right);
            int max = leftHeight > rightHeight ? leftHeight : rightHeight;
            return max + 1;
        }

    }
}
