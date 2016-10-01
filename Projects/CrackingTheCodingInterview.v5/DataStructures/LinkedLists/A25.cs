using Common;
using Common.DataStructures.LinkedLists;

namespace CrackingTheCodingInterview.v5.DataStructures.LinkedLists
{
    //You have two numbers represented by a linked list, where each node contains a
    //single digit.Thedigits are stored in reverse order, such that the Ts digit is at the
    //head of the list. Write a function that adds the two numbers and returns the sum
    //as a linked lis
    //
    //EXAMPLE
    //Input: (7-> 1 -> 6) + (5 -> 9 -> 2).That is, 617 + 295.
    //Output: 2 -> 1 -> 9.That is, 912.
    public class A25: IProgram
    {
        public void Run(string[] args)
        {
            var first = Nodes.Build(7, 1, 6);
            var second = Nodes.Build(5, 9, 2);
            var result = Sum(first, second);
            result.Dump();
        }

        private Node<int> Sum(Node<int> headA, Node<int> headB)
        {
            Node<int> head = null;
            Node<int> tail = null;

            var currentA = headA;
            var currentB = headB;
            int carry = 0;
            while (currentA != null && currentB != null)
            {
                var valueA = currentA?.Data ?? 0;
                var valueB = currentB?.Data ?? 0;

                var sum = valueA + valueB + carry;
                var current = Nodes.Create(sum % 10);
                carry = sum/10;
                if (head == null)
                {
                    head = current;
                    tail = current;
                }
                else
                {
                    tail.Next = current;
                    tail = current;
                }

                currentA = currentA?.Next;
                currentB = currentB?.Next;
            }

            if (carry != 0)
            {
                tail.Next = Nodes.Create(carry);
            }

            return head;
        }
    }
}
