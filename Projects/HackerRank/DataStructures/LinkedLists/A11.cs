using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.DataStructures.LinkedLists;

namespace HackerRank.DataStructures.LinkedLists
{
    //Delete duplicate-value nodes from a sorted linked list
    //https://www.hackerrank.com/challenges/delete-duplicate-value-nodes-from-a-sorted-linked-list
    class A11 : IProgram
    {
        public void Run(string[] args)
        {
            //Node head = Trees.build(1, 1, 3, 3, 5, 6);
            var head = global::Common.DataStructures.LinkedLists.LinkedLists.Build(1, 1, 1, 1, 1, 1, 1);
            var result = RemoveDuplicates(head);
            result.Dump();
        }

        private Node<int> RemoveDuplicates(Node<int> head)
        {
            if (head == null)
            {
                return null;
            }

            var current = head.Next;
            var tail = head;
            while (current != null)
            {
                if (current.Data != tail.Data)
                {
                    tail.Next = current;
                    tail = current;
                }

                current = current.Next;
            }
            tail.Next = null;

            return head;
        }

    }
}
