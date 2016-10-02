using System.Collections.Generic;
// ReSharper disable InconsistentNaming

namespace Common.Utility.Java
{
    public class LinkedList<T> : Queue<T>
    {
    }

    public static class QueueExtensions
    {
        public static void add<T>(this Queue<T> extended, T value)
        {
            extended.Enqueue(value);
        }

        public static T poll<T>(this Queue<T> extended)
        {
            var dequeue = extended.Dequeue();
            return dequeue;
        }

        public static int size<T>(this Queue<T> extended)
        {
            return extended.Count;
        }

    }
}
