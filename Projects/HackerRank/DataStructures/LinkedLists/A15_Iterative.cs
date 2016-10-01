using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.DataStructures.LinkedLists;

namespace HackerRank.DataStructures.LinkedLists
{
    //Reverse a doubly linked list
    //https://www.hackerrank.com/challenges/reverse-a-doubly-linked-list
    // ReSharper disable once InconsistentNaming
    class A15_Iterative : IProgram
    {
        //TODO: Tamamla Sanırm doubly linked list bozuk
        public void Run(string[] args)
        {
            var head = Nodes.Build(2, 4, 6, 8);
            var result = Reverse(head);
            result.Dump();
        }

        private Node<int> Reverse(Node<int> head)
        {
            var current = head;
            var newHead = head;
            while (current != null)
            {
                var prev = current.Previous;
                var next = current.Next;
                current.Previous = next;
                current.Next = prev;
                current = next;
                newHead = current;
            }
            return newHead;
        }

    }
}
