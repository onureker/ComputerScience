using System;
using Common;
using Common.DataStructures.LinkedLists;

namespace HackerRank.DataStructures.LinkedLists
{
    //Get Node Value
    //https://www.hackerrank.com/challenges/get-the-value-of-the-node-at-a-specific-position-from-the-tail
    class A10 : IProgram
    {
        public void Run(string[] args)
        {
            var head = global::Common.DataStructures.LinkedLists.LinkedLists.Build(1, 3, 5, 6);

            int result1 = GetNode(head, 0);
            Console.WriteLine(result1);

            int result2 = GetNode(head, 2);
            Console.WriteLine(result2);
        }

        private int GetNode(Node<int> head, int n)
        {
            var runner = head;
            for (int i = 0; i < n; i++)
            {
                if (runner == null)
                {
                    return -1;
                }

                runner = runner.Next;
            }

            var current = head;
            while (runner.Next != null)
            {
                current = current.Next;
                runner = runner.Next;
            }

            return current.Data;
        }

    }
}
