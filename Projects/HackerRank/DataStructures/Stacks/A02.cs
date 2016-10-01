using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using HackerRank.Common;

namespace HackerRank.DataStructures.Stacks
{
    //Balanced Brackets
    //https://www.hackerrank.com/challenges/balanced-brackets
    class A02 : IProgram
    {
        public void Run(string[] args)
        {
            var textReader = Console.In;
            var count = textReader.ReadLine().ParseToIntArray()[0];
            var inputs = InputParser.MultiLine(Console.In, count);
            var outputs = inputs.Select(IsBalanced).Select(b => b ? "YES" : "NO").ToArray();
            outputs.ToList().ForEach(Console.WriteLine);

            var input = "{{[[(())]]}}";
            bool balanced = IsBalanced(input);
            Console.WriteLine(balanced);
        }

        private bool IsBalanced(string input)
        {
            IDictionary<char, char> lookups = new Dictionary<char, char>();
            lookups.Add('{', '}');
            lookups.Add('(', ')');
            lookups.Add('[', ']');

            var stack = new Stack<char>();

            foreach (var currentChar in input)
            {
                if (lookups.Keys.Contains(currentChar))
                {
                    stack.Push(currentChar);
                    continue;
                }

                if (lookups.Values.Contains(currentChar))
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }

                    var topCharacter = stack.Pop();
                    var lookup = lookups[topCharacter];
                    if (currentChar != lookup)
                    {
                        return false;
                    }
                    continue;
                }
            }

            return stack.Count == 0;
        }
    }
}