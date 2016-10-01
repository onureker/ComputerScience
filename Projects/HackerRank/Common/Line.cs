using System;
using System.Linq;

namespace HackerRank.Common
{
    public static class Line
    {
        public static Func<string, int> ToInt = int.Parse;


        public static string[] ParseWithSpace(this string line)
        {
            return line.Split(' ');
        }

        public static int[] ParseToIntArray(this string line)
        {
            return line.ParseWithSpace().Select(int.Parse).ToArray();
        }

        public static string[] ToCharacters(this string line)
        {
            return line.ToCharArray().Select(c => c.ToString()).ToArray();
        }
    }
}
