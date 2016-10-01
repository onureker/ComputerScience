using System;
using System.Collections.Generic;
using Common;
using Common.DataStructures.Arrays;
using HackerRank.Common;

namespace HackerRank.DataStructures.Stacks
{
    //Maximum Element
    //https://www.hackerrank.com/challenges/maximum-element
    class A01 : IProgram
    {
        private const int Push = 1;
        private const int DeleteTop = 2;
        private const int PrintMax = 3;

        public void Run(string[] args)
        {
            //int[][] commands = InputParser.MultiLine(Line.ParseToIntArray);
            int[][] commands = ArrayBuilder<int>.TwoDimension()
                .AddLine(Push, 97)
                .AddLine(DeleteTop)
                .AddLine(Push, 20)
                .AddLine(DeleteTop)
                .AddLine(Push, 26)
                .AddLine(Push, 20)
                .AddLine(DeleteTop)
                .AddLine(PrintMax)
                .AddLine(Push, 91)
                .AddLine(PrintMax)
                .Build();

            Execute(commands);
        }

        private void Execute(int[][] commands)
        {
            var values = new Stack<int>();
            var maximums = new Stack<int>();
            maximums.Push(int.MinValue);

            foreach (int[] currentCommand in commands)
            {
                int commandType = currentCommand[0];

                if (commandType == Push)
                {
                    var value = currentCommand[1];
                    var max = maximums.Peek();
                    values.Push(value);
                    if (value >= max)
                    {
                        maximums.Push(value);
                    }

                    continue;
                }

                if (commandType == DeleteTop)
                {
                    var value = values.Pop();
                    var max = maximums.Peek();
                    if (value == max)
                    {
                        maximums.Pop();
                    }
                    continue;
                }

                if (commandType == PrintMax)
                {
                    var max = maximums.Peek();
                    Console.WriteLine(max);
                    continue;
                }
            }
        }

    }
}
