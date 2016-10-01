using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Common.DataStructures.Arrays;

namespace HackerRank.DataStructures.Queues
{

    //Truck Tour
    //https://www.hackerrank.com/challenges/truck-tourS
    class A03: IProgram
    {
        public void Run(string[] args)
        {
            //var count = InputParser.ParseHeader(Console.In)[0];
            //var pumps = InputParser.MultiLine(Console.In, count).Select(Line.ParseToIntArray).ToArray();


            var pumps = ArrayBuilder<int>.TwoDimension()
                .AddLine(1, 5)
                .AddLine(10, 3)
                .AddLine(3, 4)
                .Build();


            int start = FindStart(pumps);
            Console.WriteLine(start);
        }

        private int FindStart(int[][] pumps)
        {
            Queue<int> queue = new Queue<int>();
            pumps.Select(pump => pump[0] - pump[1]).ToList().ForEach(i => queue.Enqueue(i));

            int runningSum = 0;
            int index = 0;
            int startIndex = 0;
            while (queue.Count != 0)
            {
                index++;
                var current = queue.Dequeue();
                runningSum += current;
                if (runningSum >= 0)
                {
                    continue;
                }

                startIndex = index;
                queue.Enqueue(runningSum);
                runningSum = 0;
            }

            return startIndex;
        }
    }
}
