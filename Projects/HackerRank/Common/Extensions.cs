using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HackerRank.Common
{
    public static class Extensions
    {
        public static Func<string, int> ToInt = int.Parse;

        public static IEnumerable<string> ReadLines(this TextReader textReader, int count)
        {
            return Enumerable.Range(0, count).Select(i => textReader.ReadLine());
        }

        public static string[] ParseWithSpace(this string line)
        {
            return line.Split(' ');
        }

        public static int[] ParseToIntArray(this string line)
        {
            return line.ParseToArray(ToInt);
        }

        public static T[] ParseToArray<T>(this string line, Func<string, T> convertorFunc)
        {
            return line.ParseWithSpace().Select(convertorFunc).ToArray();
        }

        public static string[] ToCharacters(this string line)
        {
            return line.ToCharArray().Select(c => c.ToString()).ToArray();
        }

    }
}
