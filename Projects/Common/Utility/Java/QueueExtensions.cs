using System.Collections.Generic;

namespace Common.Utility.Java
{
    public class LinkedList<T> : Queue<T>
    {
    }

    public static class QueueExtensions
    {
        // ReSharper disable once InconsistentNaming
        public static void add<T>(this Queue<T> extended, T value)
        {
            extended.Enqueue(value);
        }

        // ReSharper disable once InconsistentNaming
        public static T poll<T>(this Queue<T> extended)
        {
            var dequeue = extended.Dequeue();
            return dequeue;
        }

        // ReSharper disable once InconsistentNaming
        public static int size<T>(this Queue<T> extended)
        {
            return extended.Count;
        }

    }
}
