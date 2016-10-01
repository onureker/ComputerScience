using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.DataStructures.Arrays;
using HackerRank.Common;

namespace HackerRank.DataStructures.Stacks
{
    //Largest Rectangle
    //https://www.hackerrank.com/challenges/largest-rectangle
    class A03_Iterative : IProgram
    {
        public void Run(string[] args)
        {
            //var input = ArrayBuilder<int>.New(8, 5, 9, 3, 7, 4, 6);
            //var input = ArrayBuilder<int>.New(1, 2, 3, 4, 5);
            var input = ArrayBuilder<int>.New(1, 8, 8, 8, 7, 1, 1);
            //var input = InputParser.OneDimension();

            var result = FindMax(input);
            Console.WriteLine(result);
            
        }

        private int FindMax(int[] input)
        {
            int maxArea = int.MinValue;

            for (int i = 0; i < input.Length; i++)
            {
                int minValue = int.MaxValue;

                for (int j = i; j < input.Length; j++)
                {
                    var current = input[j];
                    if (current < minValue)
                    {
                        minValue = current;
                    }

                    var currentArea = minValue * (j - i + 1);
                    if (currentArea > maxArea)
                    {
                        maxArea = currentArea;
                    }
                }
            }

            return maxArea;
        }
    }
}
