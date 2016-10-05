using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.DataStructures.Arrays;
using Common.DataStructures.Trees;

namespace CrackingTheCodingInterview.v5.DataStructures.TreesAndGraphs
{
    //Given a sorted (increasingorder) array with unique integer elements, 
    //write an algorithm to createa binary search tree with minimal height.
    class A03: IProgram
    {
        public void Run(string[] args)
        {
            var input = ArrayBuilder<int>.New(1, 2, 3, 4, 5, 6, 7);
            Node root = BuildBinarySearchTree(input, 0, input.Length-1);
            root.Dump();
            Console.WriteLine(root);
        }

        private Node BuildBinarySearchTree(int[] input, int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            int pivot = (start + end)/2;
            int value = input[pivot];
            Node node = new Node(value);
            node.Left = BuildBinarySearchTree(input, start, pivot - 1);
            node.Right = BuildBinarySearchTree(input, pivot + 1, end);

            return node;
        }
    }
}
