using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.DataStructures.Arrays;
using HackerRank.Common;

namespace HackerRank.DataStructures.Stacks
{
    //Simple Text Editor
    //https://www.hackerrank.com/challenges/simple-text-editor
    class A04 : IProgram
    {
        public void Run(string[] args)
        {
            /*
            var textReader = Console.In;
            var count = Line.ParseToIntArray(textReader.ReadLine())[0];
            var commands = InputParser.MultiLine(textReader, count).Select(s => s.Split(' ')).ToArray();
            */

            var commands = ArrayBuilder<string>.TwoDimension()
                .AddLine("1", "abc")
                .AddLine("3", "3")
                .AddLine("2", "3")
                .AddLine("1", "xy")
                .AddLine("3", "2")
                .AddLine("4")
                .AddLine("4")
                .AddLine("3", "1")
                .Build();

            Execute(commands);
        }

        private void Execute(string[][] commands)
        {
            string current = string.Empty;
            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < commands.Length; i++)
            {
                var command = commands[i];
                var commandType = command[0];

                if (commandType == "1")
                {
                    stack.Push(current);
                    var value = command[1];
                    current += value;
                    continue;
                }

                if (commandType == "2")
                {
                    stack.Push(current);
                    int count = Convert.ToInt32(command[1]);
                    current = current.Remove(current.Length - count, count);
                    continue;
                }

                if (commandType == "3")
                {
                    int index = Convert.ToInt32(command[1]);
                    Console.WriteLine(current[index-1]);
                    continue;
                }

                if (commandType == "4")
                {
                    current = stack.Pop();
                    continue;
                }
            }
        }
    }
}
