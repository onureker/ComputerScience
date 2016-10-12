using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.DataStructures.Trees;

namespace HackerRank.DataStructures.Trees
{
    //Binary Search Tree : Lowest Common Ancestor
    //https://www.hackerrank.com/challenges/binary-search-tree-lowest-common-ancestor
    class A09 : IProgram
    {
        public void Run(string[] args)
        {
            Node root = global::Common.DataStructures.Trees.Trees.Parse("4(2(1,3),7(6))");
            var result = LowestCommonAncestor(root, 1, 3);
            result.Dump();
        }

        public Node LowestCommonAncestor(Node root, int v1, int v2)
        {
            var data = root.data;
            if (v1 < data && v2 < data)
            {
                return LowestCommonAncestor(root.left, v1, v2);
            }
            if (v1 > data && v2 > data)
            {
                return LowestCommonAncestor(root.right, v1, v2);
            }

            return root;
        }
    }
}
