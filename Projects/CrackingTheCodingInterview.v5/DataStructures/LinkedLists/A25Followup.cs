using Common;
using Common.DataStructures.LinkedLists;

namespace CrackingTheCodingInterview.v5.DataStructures.LinkedLists
{
    //Suppose the digits are stored in forward order. Repeat the above problem.
    //EXAMPLE
    //Input: (6 -> 1 -> 7) + (2 -> 9 -> 5).That is, 617 + 295.
    //Output: 9 -> 1 -> 2.That is, 912.

    public class A25Followup: IProgram
    {
        public void Run(string[] args)
        {
            var first = Nodes.Build(1, 2, 3, 4);
            var second = Nodes.Build(5, 6, 7);
            var firstLength = first.Length();
            var secondLength = second.Length();
            int maxLength = firstLength > secondLength ? firstLength : secondLength;

            first = first.PadLeft(0, maxLength - firstLength + 1);
            second = second.PadLeft(0, maxLength - secondLength + 1);

            first.Dump();
            second.Dump();

            var result = Sum(first, second);
            result.Dump();
        }

        private Node<int> Sum(Node<int> first, Node<int> second)
        {
            if (first == null && second == null)
            {
                return null;
            }

            Node<int> child = Sum(first.Next, second.Next);

            var carry = child?.Data / 10;
            if (child != null)
            {
                child.Data = child.Data % 10;
            }
            
            var result = first.Data + second.Data + carry.GetValueOrDefault();
            var node = Nodes.Create(result);
            node.Next = child;
            return node;
        }
    }
}
