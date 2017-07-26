using System;
using Common;
using Common.DataStructures.Arrays;

namespace HackerRank.DataStructures.Arrays
{
    //2D Array - DS
    //https://www.hackerrank.com/challenges/2d-array
    // ReSharper disable once InconsistentNaming
    class A02_2DArrayDS : IProgram
    {
        public void Run(string[] args)
        {
            int[][] arr = ArrayBuilder<int>.TwoDimension()
                .AddLine(1, 1, 1, 0, 0, 0)
                .AddLine(0, 1, 0, 0, 0, 0)
                .AddLine(1, 1, 1, 0, 0, 0)
                .AddLine(0, 0, 2, 4, 4, 0)
                .AddLine(0, 0, 0, 2, 0, 0)
                .AddLine(0, 0, 1, 2, 4, 0)
                .Build();

            int result = FixMaxHourglassSum(arr);
            Console.WriteLine(result);
        }

        private int FixMaxHourglassSum(int[][] input)
        {
            int max = int.MinValue;
            for (int i = 0; i < input.Length - 2; i++)
            {
                for (int j = 0; j < input[0].Length - 2; j++)
                {
                    int sum = HourglassSum(i, j, input);
                    if (max < sum)
                    {
                        max = sum;
                    }
                }
            }

            return max;
        }

        private int HourglassSum(int x, int y, int[][] input)
        {
            int sum1 = input[y][x] + input[y][x + 1] + input[y][x + 2];
            int sum2 = input[y + 1][x + 1];
            int sum3 = input[y + 2][x] + input[y + 2][x + 1] + input[y + 2][x + 2];

            int sum = sum1 + sum2 + sum3;
            return sum;
        }
    }
}
