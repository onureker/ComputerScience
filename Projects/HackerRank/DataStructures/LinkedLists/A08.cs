using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.DataStructures.LinkedLists;

namespace HackerRank.DataStructures.LinkedLists
{
    //Compare two linked lists
    //https://www.hackerrank.com/challenges/compare-two-linked-lists
    class A08 : IProgram
    {
        public void Run(string[] args)
        {
            var headA = Nodes.Build(3, 1, 2);
            var headB = Nodes.Build(3, 1, 2);
            int result = CompareLists(headA, headB);
            Console.WriteLine(result);
        }

        int CompareLists(Node<int> headA, Node<int> headB)
        {
            if (headA == null && headB == null)
            {
                return 1;
            }

            var currentA = headA;
            var currentB = headB;
            while (currentA != null || currentB != null)
            {
                if (currentA == null || currentB == null)
                {
                    return 0;
                }

                if (currentA.Data != currentB.Data)
                {
                    return 0;
                }

                currentA = currentA.Next;
                currentB = currentB.Next;
            }

            return 1;
        }

    }
}
