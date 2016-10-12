using Common;
using Common.DataStructures.LinkedLists;

namespace HackerRank.DataStructures.LinkedLists
{
    //Insert a node at the head of a linked list
    //https://www.hackerrank.com/challenges/insert-a-node-at-the-head-of-a-linked-list
    class A03 : IProgram
    {
        public void Run(string[] args)
        {
            var head = global::Common.DataStructures.LinkedLists.LinkedLists.Build(1);
            var result = Insert(head, 2);
            result.Dump();
        }

        private Node<int> Insert(Node<int> head, int x)
        {
            var node = global::Common.DataStructures.LinkedLists.LinkedLists.Create(x);
            node.Next = head;
            return node;
        }


    }
}
