using Common;
using Common.DataStructures.LinkedLists;

namespace HackerRank.DataStructures.LinkedLists
{
    //Inserting a Node Into a Sorted Doubly Linked List
    //https://www.hackerrank.com/challenges/insert-a-node-into-a-sorted-doubly-linked-list
    // ReSharper disable once InconsistentNaming
    class A14_Recursive: IProgram
    {
        public void Run(string[] args)
        {
            var head = Nodes.Build(2, 4, 6);
            head.Dump();
            int data = 5;
            var result = SortedInsert(head, data);
            result.Dump();
        }

        //HACK: Güzel
        //TODO: Iteratifi de ekle
        private Node<int> SortedInsert(Node<int> head, int data)
        {
            if (head == null)
            {
                return Nodes.Build(data);
            }

            if (data > head.Data)
            {
                var rest = SortedInsert(head.Next, data);
                head.Next = rest;
                rest.Previous = head;
                return head;
            }

            var n = Nodes.Build(data);
            n.Next = head;
            head.Previous = n;
            return n;
        }

    }
}
