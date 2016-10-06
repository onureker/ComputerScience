using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Utility.Java;

// ReSharper disable InconsistentNaming

namespace HackerRank.DataStructures.Trees
{
    //Tree: Huffman Decoding
    //https://www.hackerrank.com/challenges/tree-huffman-decoding
    class A08 : IProgram
    {
        class Node
        {
            public int frequency; // the frequency of this tree
            public char data;
            public Node left, right;
        }

        public void Run(string[] args)
        {
            Node root = new Node { frequency = 5 };
            root.left = new Node { frequency = 2 };
            root.right = new Node { frequency = 3, data = 'A' };
            root.left.left = new Node {frequency = 1, data = 'B'};
            root.left.right = new Node {frequency = 1, data = 'C'};

            decode("1001011", root);
        }

        void decode(String S, Node root)
        {
            String result = decodeInternal(S, root);
            Console.WriteLine(result);
        }

        String decodeInternal(String S, Node root)
        {
            String result = "";
            char[] charArray = S.toCharArray();
            for (int index = 0; index < S.length();)
            {
                Node current = root;
                while (current.data == '\0')
                {
                    char currentChar = charArray[index++];
                    current = currentChar  == '0' ? current.left : current.right;
                }

                result += current.data;
            }

            return result;
        }

    }
}
