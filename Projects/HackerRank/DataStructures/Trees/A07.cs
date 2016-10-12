using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.DataStructures.Trees;

namespace HackerRank.DataStructures.Trees
{
    //Binary Search Tree : Insertion
    //https://www.hackerrank.com/challenges/binary-search-tree-insertion
    class A07 : IProgram
    {
        public void Run(string[] args)
        {
            var root = global::Common.DataStructures.Trees.Trees.Parse("4(2(1,3),7)");
            int value = 6;
            var result = Insert(root, value);
        }

        private Node Insert(Node root, int value)
        {
            if (root == null)
            {
                Node inserted = new Node();
                inserted.data = value;
                return inserted;
            }

            if (root.data < value)
            {
                root.right = Insert(root.right, value);
            }
            else
            {
                root.left = Insert(root.left, value);
            }

            return root;
        }

    }
}
