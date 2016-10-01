using System;
using System.Collections.Generic;
using Common;
using Common.DataStructures.Arrays;

namespace HackerRank.DataStructures.Queues
{
    //Queue using Two Stacks
    //https://www.hackerrank.com/challenges/queue-using-two-stacks
    class A05 : IProgram
    {
        public void Run(string[] args)
        {
            int[][] commands = ArrayBuilder<int>.TwoDimension()
                .AddLine(1, 42)
                .AddLine(2)
                .AddLine(1, 14)
                .AddLine(3)
                .AddLine(1, 28)
                .AddLine(3)
                .AddLine(1, 60)
                .AddLine(1, 78)
                .AddLine(2)
                .AddLine(2)
                .Build();

            Execute(commands);
        }

        private void Execute(int[][] commands)
        {
            Stack<int> pushStack = new Stack<int>();
            Stack<int> popStack = new Stack<int>();

            foreach (int[] currentCommand in commands)
            {
                int commandType = currentCommand[0];
                if (commandType == 1)
                {
                    int value = currentCommand[1];
                    pushStack.Push(value);
                    continue;
                }

                if (popStack.Count == 0)
                {
                    while (pushStack.Count != 0)
                    {
                        popStack.Push(pushStack.Pop());
                    }
                }

                if (commandType == 2)
                {
                    popStack.Pop();
                    continue;
                }

                if (commandType == 3)
                {
                    int value = popStack.Peek();
                    Console.WriteLine(value);
                    continue;
                }
            }
        }

    }
}
