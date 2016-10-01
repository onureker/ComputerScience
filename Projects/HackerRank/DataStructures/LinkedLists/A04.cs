using Common;
using Common.DataStructures.LinkedLists;

namespace HackerRank.DataStructures.LinkedLists
{
    //Insert a node at a specific position in a linked list
    //https://www.hackerrank.com/challenges/insert-a-node-at-a-specific-position-in-a-linked-list
    class A04: IProgram
    {
        public void Run(string[] args)
        {
            var head = Nodes.Build(3, 1, 4);
            var result = InsertNth(head, 2, 1);
            result.Dump();
        }

        Node<int> InsertNth(Node<int> head, int data, int position)
        {
            var node = Nodes.Create(data);
            if (position == 0)
            {
                node.Next = head;
                return node;
            }

            var current = head;
            for (int i = 1; i < position; i++)
            {
                current = current.Next;
            }

            node.Next = current.Next;
            current.Next = node;
            return head;
        }

    }
}
