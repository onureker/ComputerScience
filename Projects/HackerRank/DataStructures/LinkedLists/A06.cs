using System;
using Common;
using Common.DataStructures.LinkedLists;
using Nodes = Common.DataStructures.LinkedLists.Nodes;

namespace HackerRank.DataStructures.LinkedLists
{
    //Print in Reverse
    //https://www.hackerrank.com/challenges/print-the-elements-of-a-linked-list-in-reverse
    class A06 : IProgram
    {
        public void Run(string[] args)
        {
            var head = Nodes.Build(3, 1, 4);
            ReversePrint(head);
        }

        private void ReversePrint(Node<int> current)
        {
            if (current == null)
            {
                return;
            }

            ReversePrint(current.Next);
            Console.WriteLine(current.Data);
        }

    }
}
