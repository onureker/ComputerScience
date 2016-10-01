using System;
using System.Linq;

namespace Common.DataStructures.Arrays
{
    public static class ArrayExtensions
    {
        public static void Dump<T>(this T[] extended)
        {
            var strings = extended.Select(x => x.ToString());
            var text = string.Join(" ", strings);
            Console.WriteLine(text);
        }

        public static void Dump<T>(this T[][] array)
        {
            array.ToList().ForEach(cells => Console.WriteLine(string.Join(" ", cells)));
        }

    }
}
