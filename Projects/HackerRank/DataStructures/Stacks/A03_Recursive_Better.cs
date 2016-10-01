using System;
using System.Linq;
using Common;
using Common.DataStructures.Arrays;

namespace HackerRank.DataStructures.Stacks
{
    //Largest Rectangle
    //https://www.hackerrank.com/challenges/largest-rectangle
    //Largest rectangle of histogram..
    //INFO: http://www.informatik.uni-ulm.de/acm/Locals/2003/html/histogram.html
    class A03_Recursive_Better : IProgram
    {
        public void Run(string[] args)
        {
            //var input = ArrayBuilder<int>.New(8, 5, 9, 3, 7, 4, 6);
            //var input = ArrayBuilder<int>.New(1, 2, 3, 4, 5);
            var input = ArrayBuilder<int>.New(1, 8, 8, 8, 7, 1, 1);
            //var input = ArrayBuilder<int>.New(1, 8, 1);
            //var input = InputParser.OneDimension();

            var result = FindMax(input, 0, input.Length);
            Console.WriteLine(result);
            
        }

        // EN küçük sayıya göre sağa ve sola bölüp, üçünün max'ını alabilirim
        private int FindMax(int[] input, int start, int end)
        {
            int minIndex = FindMinIndex(input, start, end);
            if (minIndex == -1)
            {
                return -1;
            }

            var current = input[minIndex]*(end - start);
            var leftMax = FindMax(input, start, minIndex);
            var rightMax = FindMax(input, minIndex + 1, end);

            var result = new[] {current, leftMax, rightMax}.Max();
            return result;
        }

        private int FindMinIndex(int[] input, int start, int end)
        {
            int min = int.MaxValue;
            int result = -1;
            for (int i = start; i < end; i++)
            {
                var current = input[i];
                if (current >= min)
                {
                    continue;
                }

                min = current;
                result = i;
            }

            return result;
        }
    }
}
