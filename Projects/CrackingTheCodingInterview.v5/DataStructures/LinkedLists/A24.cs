using Common;
using Common.DataStructures.LinkedLists;

namespace CrackingTheCodingInterview.v5.DataStructures.LinkedLists
{
    public class A24: IProgram
    {
        //Write code to partition a linked list around avalue x, such that all nodes less than x come before all nodes greater than or equal to x.
        public void Run(string[] args)
        {
            Node<int> input = Nodes.Build(3, 1, 4, 3, 7, 1, 9, 10);
            //PartitionBy1(input, 4).Dump();
            PartitionBy2(input, 4).Dump();
        }

        private Node<int> PartitionBy1(Node<int> head, int value)
        {
            if (head == null)
            {
                return null;
            }

            Node<int> smallersHead = null;
            Node<int> smallersTail = null;

            Node<int> biggersHead = null;
            Node<int> biggersTail = null;

            for (var current = head; current != null; current = current.Next)
            {
                var smaller = current.Data < value;
                if (smaller)
                {
                    if (smallersHead == null)
                    {
                        smallersHead = current;
                        smallersTail = current;
                        continue;
                    }

                    smallersTail.Next = current;
                    smallersTail = current;
                }
                else
                {
                    if (biggersHead == null)
                    {
                        biggersHead = current;
                        biggersTail = current;
                        continue;
                    }

                    biggersTail.Next = current;
                    biggersTail = current;
                }
            }

            if (smallersTail == null)
            {
                return biggersHead;
            }

            smallersTail.Next = biggersHead;
            return smallersHead;
        }

        private Node<int> PartitionBy2(Node<int> head, int value)
        {
            Node<int> smallerHead = null;
            Node<int> biggerHead = null;

            Node<int> current = head;
            while (current != null)
            {
                var next = current.Next;
                var smaller = current.Data < value;
                if (smaller)
                {
                    current.Next = smallerHead;
                    smallerHead = current;
                }
                else
                {
                    current.Next = biggerHead;
                    biggerHead = current;
                }

                current = next;
            }

            if (smallerHead == null)
            {
                return null;
            }

            var smallerTail = smallerHead;
            while (smallerTail.Next != null)
            {
                smallerTail = smallerTail.Next;
            }

            smallerTail.Next = biggerHead;
            return smallerHead;
        }

    }
}
