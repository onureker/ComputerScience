using System;
using Common;
using Common.DataStructures.Trees;

namespace CrackingTheCodingInterview.v5.DataStructures.TreesAndGraphs
{
    //Design an algorithm and write code to find the first common ancestor of two nodes in a binary tree.
    //Avoid storing additional nodes in a data structure.
    //NOTE: This is not necessarily a binary search tree.
    class A07Solution1: IProgram
    {
        public void Run(string[] args)
        {
            var root = TreeBuilder.Parse("3(1,5(,8))");

            var node3 = root.left;
            var node8 = root.right.right;
            var result = LowestCommonAncestor(root, node3, node8);
            result.Dump();
        }

        public Node LowestCommonAncestor(Node root, Node node1, Node node2)
        {
            if (root == node1 || root == node2)
            {
                return root;
            }

            bool node1Left = IsAChildOf(root.Left, node1);
            bool node2Left = IsAChildOf(root.Left, node2);

            if (node1Left && node2Left)
            {
                return LowestCommonAncestor(root.Left, node1, node2);
            }

            if (!node1Left && !node2Left)
            {
                return LowestCommonAncestor(root.Right, node1, node2);
            }

            return root;
        }

        private bool IsAChildOf(Node parent, Node searched)
        {
            if (parent == null)
            {
                return false;
            }

            if (parent == searched)
            {
                return true;
            }

            var result = IsAChildOf(parent.Left, searched) || IsAChildOf(parent.Right, searched);
            return result;
        }
    }
}
