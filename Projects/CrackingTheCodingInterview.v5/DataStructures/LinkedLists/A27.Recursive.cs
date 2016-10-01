using Common.DataStructures.LinkedLists;

namespace CrackingTheCodingInterview.v5.DataStructures.LinkedLists
{
    partial class A27
    {
        private bool RecursiveAnswer(Node<int> head)
        {
            var length = head.Length();
            var recursive = Recursive(head, length, length);
            return recursive;
        }

		//Mine
        private bool Recursive(Node<int> head, int length, int current)
        {
            if (current == 0)
            {
                return true;
            }

            if (current == 1)
            {
                head.Data = head.Next.Data;
                head.Next = head.Next.Next;
                return true;
            }

            bool childTrue = Recursive(head.Next, length, current - 2);
            if (!childTrue)
            {
                return false;
            }

            if (head.Data != head.Next.Data)
            {
                return false;
            }

            if (current != length)
            {
                head.Data = head.Next.Next.Data;
                head.Next = head.Next.Next.Next;
            }
            return true;
        }
    }
}
