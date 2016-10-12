using Common;
using Common.DataStructures.LinkedLists;

namespace HackerRank.DataStructures.LinkedLists
{
    //Insert a Node at the Tail of a Linked List
    //https://www.hackerrank.com/challenges/insert-a-node-at-the-tail-of-a-linked-list
    class A02 : IProgram
    {
        public void Run(string[] args)
        {
            var head = global::Common.DataStructures.LinkedLists.LinkedLists.Build(1, 2);
            var result = Insert(head, 3);
            result.Dump();
        }

        public static Node<int> Insert(Node<int> head, int data)
        {
            var node = global::Common.DataStructures.LinkedLists.LinkedLists.Create(data);
            if (head == null)
            {
                return node;
            }

            var current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = node;
            return head;
        }

    }
}
