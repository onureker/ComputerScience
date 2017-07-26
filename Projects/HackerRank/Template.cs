using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerRank.Common;

namespace HackerRank
{
    class Template
    {
        private static void Main2(String[] args)
        {
            var textReader = Console.In;
            int count = textReader.ReadLine().ParseToIntArray()[0];
            int[][] inputs = textReader.ReadLines(count).Select(Extensions.ParseToIntArray).ToArray();
            //var outputs = inputs.Select(IsBalanced).Select(b => b ? "YES" : "NO").ToArray();
        }
    }
}
