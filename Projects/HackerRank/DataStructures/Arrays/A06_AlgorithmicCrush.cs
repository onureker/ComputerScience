using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using Common;
using Common.DataStructures.Arrays;

namespace HackerRank.DataStructures.Arrays
{
    //Algorithmic Crush
    //https://www.hackerrank.com/challenges/crush
    // ReSharper disable once InconsistentNaming
    class A06_AlgorithmicCrush : IProgram
    {
        public void Run(string[] args)
        {
            /*
            int size = 4;
            int[][] queries = ArrayBuilder<int>.TwoDimension()
                .AddLine(2, 3, 603)
                .AddLine(1, 1, 286)
                .AddLine(4, 4, 882)
                .Build();
                */
            int size = 5;
            int[][] queries = ArrayBuilder<int>.TwoDimension()
                .AddLine(1, 2, 100)
                .AddLine(2, 5, 100)
                .AddLine(3, 4, 100)
                .Build();
            
            var result = Execute(size, queries);
            Console.WriteLine(result);
        }

        private long Execute(int size, int[][] queries)
        {
            var increments = new int[size+1];

            foreach (var query in queries)
            {
                var start = query[0] - 1;
                var end = query[1] - 1;
                var increment = query[2];

                increments[start] += increment;
                increments[end+1] += (increment * -1);
            }

            long current = 0;
            long max = 0;
            for (int i = 0; i < size; i++)
            {
                current += increments[i];
                if (max < current)
                {
                    max = current;
                }
            }
            return max;
        }

    }
}
