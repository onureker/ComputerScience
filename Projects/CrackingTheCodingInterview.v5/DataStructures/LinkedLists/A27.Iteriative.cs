using System.Collections.Generic;
using Common.DataStructures.LinkedLists;

namespace CrackingTheCodingInterview.v5.DataStructures.LinkedLists
{
    partial class A27
    {
        //Mine..
        private bool IterativeAnswer(Node<int> head)
        {
            Node<int> current = head;
            Node<int> runner = head;
            Stack<int> stack = new Stack<int>();
            while (runner?.Next != null)
            {
                stack.Push(current.Data);
                current = current.Next;
                runner = runner.Next.Next;
            }

            if (runner == null) // Tek sayı (Odd)
            {
                current = current.Next;
            }

            while (current != null)
            {
                int value = stack.Pop();
                if (current.Data == value)
                {
                    current = current.Next;
                    continue;
                }

                return false;
            }

            return true;
        }

    }
}
