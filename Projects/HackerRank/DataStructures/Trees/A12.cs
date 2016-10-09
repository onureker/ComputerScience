using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using HackerRank.Common;

namespace HackerRank.DataStructures.Trees
{
    //Square-Ten Tree
    //https://www.hackerrank.com/challenges/square-ten-tree
    class A12 : IProgram
    {
        public void Run(string[] args)
        {
            var textReader = Console.In;
            //int left = textReader.ReadLine().ParseToIntArray()[0];
            //int right = textReader.ReadLine().ParseToIntArray()[0];
            int left = 42;
            int right = 1024;
            //int left = 1;
            //int right = 10;

            var sequence = GetSequence(left, right);
            Console.WriteLine(sequence.Count);
            sequence.Select(tuple => tuple.Item1 + " " + tuple.Item2).ToList().ForEach(Console.WriteLine);
        }

        private IList<Tuple<int, int>> GetSequence(int left, int right)
        {
            IList<Tuple<int, int>> sequence = new List<Tuple<int, int>>();

            int level = 0;
            int current = left - 1;
            while (true)
            {
                int multiplier = (int)Math.Pow(10, level);
                int levelRelativeValue = current/multiplier;
                int remaining = levelRelativeValue % 10;

                if (remaining == 0)
                {
                    level++;
                    break;
                }

                int needed = 10 - remaining;

                var tuple = new Tuple<int, int>(level, needed);
                sequence.Add(tuple);

                int increase = needed*multiplier;
                current += increase;
                level++;
            }

            current = right - current;
            while (current != 0)
            {
                int multiplier = (int)Math.Pow(10, level);
                int levelRelativeValue = current / multiplier;

                int remaining = levelRelativeValue % 10;

                var tuple = new Tuple<int, int>(level, remaining);
                sequence.Add(tuple);

                int decrease = remaining * multiplier;
                current -= decrease;

                level--;
            }

            return sequence;
        }
    }
}
