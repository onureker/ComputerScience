using System;
using System.Collections.Generic;
using Common;
using Common.DataStructures.Arrays;

namespace HackerRank.DataStructures.Arrays
{
    //Dynamic Array
    //https://www.hackerrank.com/challenges/dynamic-array
    // ReSharper disable once InconsistentNaming
    class A03_DynamicArray : IProgram
    {
        public void Run(string[] args)
        {
            int seqCount = 2;
            int[][] queries = ArrayBuilder<int>.TwoDimension()
                .AddLine(1, 0, 5)
                .AddLine(1, 1, 7)
                .AddLine(1, 0, 3)
                .AddLine(2, 1, 0)
                .AddLine(2, 1, 1)
                .Build();

            Execute(seqCount, queries);
        }

        private void Execute(int seqCount, int[][] queries)
        {
            IList<IList<int>> sequences = new List<IList<int>>();
            for (int i = 0; i < seqCount; i++)
            {
                sequences.Add(new List<int>());
            }

            int lastAns = 0;
            foreach (var query in queries)
            { 
                int type = query[0];
                int x = query[1];
                int y = query[2];

                int seqIndex = (x ^ lastAns) % seqCount;
                IList<int> currentSeq = sequences[seqIndex];

                if (type == 1)
                {
                    currentSeq.Add(y);
                    continue;
                }

                if (type == 2)
                {
                    int currentValue = currentSeq[y % currentSeq.Count];
                    lastAns = currentValue;
                    Console.WriteLine(lastAns);
                }
            }
        }
    }
}
