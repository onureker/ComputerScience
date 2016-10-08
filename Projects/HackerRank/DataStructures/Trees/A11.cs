using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.DataStructures.Trees;

namespace HackerRank.DataStructures.Trees
{
    //Is This a Binary Search Tree?
    //https://www.hackerrank.com/challenges/is-binary-search-tree
    class A11 : IProgram
    {
        public void Run(string[] args)
        {
            var root = TreeBuilder.Parse("3(5(1,4),2(6))");
            var result = CheckBST(root, int.MinValue, int.MaxValue);
            Console.WriteLine(result);
        }

        public bool CheckBST(Node root, int min, int max)
        {
            if (root == null)
            {
                return true;
            }

            var current = root.data;
            if (current <= min || current >= max)
            {
                return false;
            }

            var leftOk = CheckBST(root.left, min, current);
            if (!leftOk)
            {
                return false;
            }

            var rightOk = CheckBST(root.right, current, max);
            if (!rightOk)
            {
                return false;
            }

            return true;
        }
    }
}
