using Common;
using Common.DataStructures.LinkedLists;

namespace HackerRank.DataStructures.LinkedLists
{
    //Reverse a linked list
    //https://www.hackerrank.com/challenges/reverse-a-linked-list
    class A07 : IProgram
    {
        public void Run(string[] args)
        {
            var head = global::Common.DataStructures.LinkedLists.LinkedLists.Build(3, 1, 4);
            var result = Reverse(head);
            result.Dump();
        }

        //HACK: Güzel
        private Node<int> Reverse(Node<int> head)
        {
            Node<int> newHead = null;
            var current = head;

            while (current != null)
            {
                var next = current.Next;
                current.Next = newHead;
                newHead = current;

                current = next;
            }

            return newHead;
        }

    }
}
