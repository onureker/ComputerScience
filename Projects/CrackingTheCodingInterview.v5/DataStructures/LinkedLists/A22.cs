using System;
using Common;
using Common.DataStructures.LinkedLists;

namespace CrackingTheCodingInterview.v5.DataStructures.LinkedLists
{
    //Implement an algorithm to find the kth to last element of a singly linked list.
    public class A22: IProgram
    {
        public void Run(string[] args)
        {
            Node<int> input = Nodes.Build(3, 1, 4, 3, 7, 1, 9, 10);

            Node<int> output = FindKthLastElement(input, 4);
            Console.WriteLine(output);

            WriteKthLastElementRecursive(input, 4);
        }

        private int WriteKthLastElementRecursive(Node<int> input, int i)
        {
            if (input == null)
            {
                return 0;
            }

            int reverseIndex = WriteKthLastElementRecursive(input.Next, i) + 1;
            if (reverseIndex == i)
            {
                Console.WriteLine(input.Data);
            }

            return reverseIndex;
        }

        private Node<int> FindKthLastElement(Node<int> head, int k)
        {
            var runner = head;
            for (int i = 0; i < k; i++)
            {
                if (runner == null)
                {
                    return null;
                }
                runner = runner.Next;
            }

            if (runner == null)
            {
                return null;
            }

            for (var current = head;;current = current.Next)
            {
                if (runner == null)
                {
                    return current;
                }

                runner = runner.Next;
            }
        }
    }
}
