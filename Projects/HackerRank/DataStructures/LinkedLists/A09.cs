using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.DataStructures.LinkedLists;

namespace HackerRank.DataStructures.LinkedLists
{
    //Merge two sorted linked lists
    //https://www.hackerrank.com/challenges/merge-two-sorted-linked-lists
    class A09 : IProgram
    {
        public void Run(string[] args)
        {
            var headA = global::Common.DataStructures.LinkedLists.LinkedLists.Build(1, 3, 5, 6);
            var headB = global::Common.DataStructures.LinkedLists.LinkedLists.Build(2, 4, 7);
            var result = MergeLists(headA, headB);
            result.Dump();
        }

        private Node<int> MergeLists(Node<int> headA, Node<int> headB)
        {
            if (headA == null)
            {
                return headB;
            }

            if (headB == null)
            {
                return headA;
            }

            var head = default(Node<int>);
            var tail = default(Node<int>);
            var currentA = headA;
            var currentB = headB;
            while (currentA != null && currentB != null)
            {
                bool smallerA = currentA.Data < currentB.Data;
                var selected = smallerA ? currentA : currentB;
                if (head == null)
                {
                    head = selected;
                    tail = selected;
                }
                else
                {
                    tail.Next = selected;
                    tail = selected;
                }

                if (smallerA)
                {
                    currentA = currentA.Next;
                }
                else
                {
                    currentB = currentB.Next;
                }
            }

            if (currentA != null)
            {
                tail.Next = currentA;
            }

            if (currentB != null)
            {
                tail.Next = currentB;
            }

            return head;
        }

    }
}
