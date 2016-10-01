using System;
using Common;
using Common.DataStructures.Arrays;

namespace CrackingTheCodingInterview.v5.DataStructures.ArraysAndStrings
{
    public class A17: IProgram
    {
        public void Run(string[] args)
        {
            int[][] matrix = ArrayBuilder<int>.TwoDimension()
                .AddLine(1, 0, 1)
                .AddLine(1, 1, 1)
                .AddLine(0, 1, 1)
                //.AddLine(1, 0, 1, 0, 1)
                //.AddLine(1, 1, 1, 0, 1)
                //.AddLine(0, 1, 1, 1, 1)
                //.AddLine(1, 1, 1, 1, 1)
                //.AddLine(1, 0, 1, 0, 1)
                //.AddLine(1, 1, 1, 1, 1)
                .Build();

            matrix.Dump();
            Console.WriteLine();
            
            //int[][] cleared1 = Clear(matrix);
            //cleared1.Dump();

            int[][] cleared2 = BetterClear(matrix);
            cleared2.Dump();
        }

        private int[][] BetterClear(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            int columZeros = 0;
            int rowZeros = 0;

            for (int y = 0; y < m; y++)
            {
                for (int x = 0; x < n; x++)
                {
                    int value = matrix[y][x];
                    if (value != 0)
                    {
                        continue;
                    }

                    int rowMask = 1 << x;
                    rowZeros |= rowMask;

                    int columnMask = 1 << y;
                    columZeros |= columnMask;
                }
            }

            for (int y = 0; y < m; y++)
            {
                for (int x = 0; x < n; x++)
                {
                    int rowMask = 1 << x;
                    if ((rowZeros & rowMask) == rowMask)
                    {
                        matrix[y][x] = 0;
                    }

                    int columnMask = 1 << y;
                    if ((columZeros & columnMask) == columnMask)
                    {
                        matrix[y][x] = 0;
                    }
                }
            }

            return matrix;
        }

        private int[][] Clear(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            int[] processed = new int[m];

            for (int y = 0; y < m; y++)
            {
                for (int x = 0; x < n; x++)
                {
                    int mask = 1 << x;
                    if ((processed[y] & mask) == mask)
                    {
                        continue;
                    }

                    processed[y] |= mask;
                    int value = matrix[y][x];
                    if (value != 0)
                    {
                        continue;
                    }

                    for (int i = 0; i < m; i++)
                    {
                        matrix[i][x] = 0;
                        processed[i] |= mask;
                    }


                    for (int i = 0; i < n; i++)
                    {
                        matrix[y][i] = 0;
                    }
                    processed[y] = (1 << n + 1) - 1;
                    break;
                }
            }

            return matrix;
        }
    }
}
