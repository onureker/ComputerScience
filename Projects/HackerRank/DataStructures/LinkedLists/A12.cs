using System;
using Common;
using Common.DataStructures.LinkedLists;

namespace HackerRank.DataStructures.LinkedLists
{
    //Cycle Detection
    //https://www.hackerrank.com/challenges/detect-whether-a-linked-list-contains-a-cycle
    class A12 : IProgram
    {
        public void Run(string[] args)
        {
            var head = global::Common.DataStructures.LinkedLists.LinkedLists.Build(1, 2, 3, 4);
            var node2 = head.Lookup(2);
            var node3 = head.Lookup(3);
            node3.Next = node2;
            //boolean result = hasCycle(head);
            var hasCycle = HasCycle(head);
            Console.WriteLine(hasCycle);
        }

        //HACK: Güzel
        private bool HasCycle(Node<int> head)
        {
            if (head == null)
            {
                return false;
            }

            var current = head;
            var runner = head;
            while (runner != null && runner.Next != null)
            {
                current = current.Next;
                runner = runner.Next.Next;

                if (current == runner)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
