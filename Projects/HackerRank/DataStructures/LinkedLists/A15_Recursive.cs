using Common;
using Common.DataStructures.LinkedLists;

namespace HackerRank.DataStructures.LinkedLists
{
    // ReSharper disable once InconsistentNaming
    class A15_Recursive: IProgram
    {
        public void Run(string[] args)
        {
            var head = global::Common.DataStructures.LinkedLists.LinkedLists.Build(2, 4, 6, 8);
            var result = Reverse(head);
            result.Dump();
        }

        //FIXME: Güzel
        private Node<int> Reverse(Node<int> node)
        {
            // If empty list, return
            if (node == null)
            {
                return null;
            }
                
            // Otherwise, swap the next and prev
            var next = node.Next;
            node.Next = node.Previous;
            node.Previous = next;

            // If the prev is now NULL, the list
            // has been fully reversed
            if (next == null)
                return node;

            // Otherwise, keep going
            return Reverse(next);
        }

    }
}
