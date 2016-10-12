using System;
using System.Diagnostics;

namespace Common.DataStructures.LinkedLists
{
    public static class LinkedLists
    {
        public static Node<T> Build<T>(params T[] values)
        {
            Node<T> head = Create(values[0]);
            Node<T> last = head;
            for (int i = 1; i < values.Length; i++)
            {
                Node<T> current = Create(values[i]);
                last.Next = current;
                current.Previous = last;

                last = current;
            }

            return head;
        }

        public static Node<T> Create<T>(T value)
        {
            Node<T> result = new Node<T>();
            result.Data = value;
            return result;
        }

        public static Node<T> Create<T>(T value, Node<T> next)
        {
            Node<T> result = Create(value);
            result.Next = next;
            return result;
        }

        public static Node<T> Create<T>(T value, Node<T> next, Node<T> previous)
        {
            Node<T> result = Create(value);
            result.Next = next;
            result.Previous = previous;
            return result;
        }

        public static void Dump<T>(this Node<T> extended)
        {
            for (Node<T> current = extended; current != null; current = current.Next)
            {
                Console.Write(current.Data + " -> ");
            }
            Console.WriteLine();
        }

        public static void Append<T>(this Node<T> extended, Node<T> node)
        {
            var current = extended;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = node;
        }

        public static Node<T> Lookup<T>(this Node<T> extended, T value)
        {
            for (Node<T> current = extended; current != null; current = current.Next)
            {
                if (!current.Data.Equals(value))
                {
                    continue;
                }

                return current;
            }

            return null;
        }

        [DebuggerStepThrough]
        public static int Length<T>(this Node<T> extended)
        {
            int result = 0;
            for (Node<T> current = extended; current != null; current = current.Next)
            {
                result++;
            }

            return result;
        }

        public static Node<T> PadLeft<T>(this Node<T> extended, T padValue, int length)
        {
            Node<T> head = extended;
            for (int i = 0; i < length; i++)
            {
                Node<T> node = Create(padValue);
                node.Next = head;
                head.Previous = node;
                head = node;
            }

            return head;
        }
    }
}
