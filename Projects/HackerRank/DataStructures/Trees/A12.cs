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
        /*
        [42; 1024] =
        [42; 42] + [43; 43] + ... + [50; 50] (9 of level 0) +
        [51; 60] + [61; 70] + ... [91; 100] (5 of level 1) +
        [101; 200] + [201; 300] + ... + [901; 1000] (9 of level 2) +
        [1001; 1010] + [1011; 1020] (2 of level 1) +
        [1021; 1021] + [1022; 1022] + [1023;1023] + [1024; 1024] (4 of level 0)
        */
        public void Run(string[] args)
        {
            var textReader = Console.In;
            //int from = textReader.ReadLine().ParseToIntArray()[0];
            //int to = textReader.ReadLine().ParseToIntArray()[0];
            //int from = 42;
            //int to = 1024;
            //int left = 42;
            //int right = 1024;
            int left = 21;
            int right = 30;

            var maxLevel = (int)Math.Log10(right);
            var pivot = (int)Math.Pow(10, maxLevel);


            var upSequence = GoUp(left-1, pivot);
            var downSequence = GoDown(pivot, right, maxLevel);

            List<Tuple<int, int>> result = new List<Tuple<int, int>>();
            result.AddRange(upSequence);
            result.AddRange(downSequence);

            Console.WriteLine(result.Count);
            result.Select(tuple => tuple.Item2 + " " + tuple.Item1).ToList().ForEach(Console.WriteLine);
        }

        private IEnumerable<Tuple<int, int>> GoDown(int pivot, int right, int level)
        {
            var result = new List<Tuple<int, int>>();
            var current = pivot;
            while (current != right)
            {
                var stepSize = (int)Math.Pow(10, level);
                var difference = (right - current) / stepSize;
                if (difference == 0)
                {
                    level--;
                    continue;
                }
                result.Add(new Tuple<int, int>(level, difference));
                current = current + (difference * stepSize);
                level--;
            }

            return result;
        }

        private IEnumerable<Tuple<int, int>> GoUp(int left, int pivot)
        {
            var result = new List<Tuple<int, int>>();
            var current = left;
            var level = 0;
            while (current != pivot)
            {
                var stepSize = (int)Math.Pow(10, level);
                var upperStepSize = (int)Math.Pow(10, level+1);
                var nearestUpperValue = (current/upperStepSize + 1)*upperStepSize;
                var difference = (nearestUpperValue - current) / stepSize;
                if (difference == 10)
                {
                    difference = 1;
                    level++;
                }
                result.Add(new Tuple<int, int>(level, difference));
                current = nearestUpperValue;
                level++;
            }

            return result;
        }

        private IList<Tuple<int, int>> GetSequenceToUp(int from, int to)
        {
            int level = GetLevel(from);
            var step = (int)Math.Pow(10, level);
            var upper = (int)Math.Pow(10, level + 1);
            if (step > to - from)
            {
                return new List<Tuple<int, int>>();
            }

            int target = to > upper ? upper : to;
            int count = (target - from) / step;
            var sequence = GetSequenceToUp(@from + count * step, to);
            var tuple = new Tuple<int, int>(level, count);
            sequence.Insert(0, tuple);

            return sequence;
        }

        private IList<Tuple<int, int>> GetSequenceToDown(int from, int to)
        {
            int level = GetLevel(from);
            var step = (int)Math.Pow(10, level);
            var upper = (int)Math.Pow(10, level + 1);
            if (upper > to)
            {
                return new List<Tuple<int, int>>();
            }

            int count = from % upper / step;
            var sequence = GetSequenceToDown(from - count * step, to);
            var tuple = new Tuple<int, int>(level, count);
            sequence.Insert(0, tuple);

            return sequence;
        }

        private int GetLevel(int value)
        {
            if (value == 0)
            {
                return 0;
            }

            int level = 0;
            int current = value;
            while (current % 10 == 0)
            {
                level++;
                current = current/10;
            }

            return level;
        }
    }
}
