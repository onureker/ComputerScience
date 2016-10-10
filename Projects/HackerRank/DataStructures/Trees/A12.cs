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
            //int from = textReader.ReadLine().ParseToIntArray()[0];
            //int to = textReader.ReadLine().ParseToIntArray()[0];
            //int from = 42;
            //int to = 1024;
            int left = 0;
            int right = 10;

            var upSequence = GetSequenceToUp(left, right);
            var pivot = (int)Math.Pow(10, upSequence.Last().Item1+1);
            var downSequence = GetSequenceToDown(right, pivot);

            List<Tuple<int, int>> result = new List<Tuple<int, int>>();
            result.AddRange(upSequence);
            result.AddRange(downSequence.Reverse());

            Console.WriteLine(result.Count);
            result.Select(tuple => tuple.Item1 + " " + tuple.Item2).ToList().ForEach(Console.WriteLine);
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

        private IList<Tuple<int, int>> GetSequenceToUp(int from, int to)
        {
            int level = GetLevel(from);
            var step = (int) Math.Pow(10, level);
            var upper = (int) Math.Pow(10, level + 1);
            if (step > to-from)
            {
                return new List<Tuple<int, int>>();
            }

            int target = to > upper ? upper : to;
            int count = (target - from) / step;
            var sequence = GetSequenceToUp(@from+ count*step, to);
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
