using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.DataStructures.Trees;

namespace CrackingTheCodingInterview.v5.DataStructures.TreesAndGraphs
{
    //Implement a function to check if a binary tree is balanced. For the purposes of this
    //question, a balanced tree is defined to be a tree such that the heights of the two
    //subtrees of any node never differ by more than one
    class A01: IProgram
    {
        public void Run(string[] args)
        {
            var root = Trees.Parse("3(4(2), 1)");
            int height = Height(root);
            string result = height != -1 ? "BALANCED" : "UNBALANCED";
            Console.WriteLine(result);
        }

        private int Height(Node root)
        {
            if (root == null)
            {
                return 0;
            }

            var leftHeight = Height(root.Left);
            if (leftHeight == -1)
            {
                return -1;
            }

            var rightHeight = Height(root.Right);
            if (rightHeight == -1)
            {
                return -1;
            }

            var diff = Math.Abs(leftHeight - rightHeight);
            if (diff > 1)
            {
                return -1;
            }

            var result = Math.Max(leftHeight, rightHeight) + 1;
            return result;
        }
    }
}
