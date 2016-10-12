using System;
using System.Linq;

namespace Common.DataStructures.Arrays
{
    public static class ArrayExtensions
    {
        public static void Dump<T>(this T[] extended)
        {
            var text = string.Join(" ", extended);
            Console.WriteLine(text);
        }

        public static void Dump<T>(this T[][] array)
        {
            array.ToList().ForEach(cells => cells.Dump());
        }

    }
}
