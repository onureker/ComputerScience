using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Common.DataStructures.Arrays;
using HackerRank.Common;

namespace HackerRank.DataStructures.Queues
{
    //Queries with Fixed Length
    //https://www.hackerrank.com/challenges/queries-with-fixed-length
    class A04 : IProgram
    {
        public void Run(string[] args)
        {
            /*
            var textReader = this.ReadInput();
            int[] header = textReader.ReadLine().ParseToIntArray();
            var values = textReader.ReadLine().ParseToIntArray();
            var ds = textReader.ReadLines(header[1]).Select(int.Parse).ToArray();

            foreach (var d in ds)
            {
                int result = FindMinOfMaxs(values, d);
                Console.WriteLine(result);
            }
            */

            var values = ArrayBuilder<int>.New(3, 2, 1, 4, 5);
            var d = 2;

            //var values = ArrayBuilder<int>.New(176641, 818878, 590130, 846132, 359913, 699520, 974627, 806346, 343832, 619769, 760242, 693331, 832192, 775549, 353117, 23950, 496548, 183204, 971799, 393071, 727476, 351337, 811496, 24595, 417701, 664960, 745806, 538176, 230403, 942316, 21481, 605695, 598531, 651683, 558460, 583357, 530911, 721611, 308228, 724620, 429167, 909353, 330152, 116815, 986067, 713467, 906132, 428600, 927889, 567272, 647109, 992614, 747948, 192884, 879696, 262543, 782487, 829272, 470060, 427956, 751730, 597177, 870616, 754791, 421830, 11676, 425656, 841955, 693419, 462693, 245403, 192649, 750201, 180732, 17450, 44723, 527618, 174579, 515786, 444844, 210843, 563425, 809540, 752036, 608529, 748313, 667439, 255643, 387412, 320353, 704213, 755272, 267902, 657989, 651762, 325654, 582887, 382501, 715426, 897450);
            //var d = 78;

            int result = FindMinOfMaxs(values, d);
            Console.WriteLine(result);
        }

        private int FindMinOfMaxs(int[] values, int size)
        {
            Stack<int> maxs = new Stack<int>();
            int min = values[0];
            maxs.Push(int.MinValue);
            maxs.Push(min);

            for (int i = 1; i < values.Length; i++)
            {
                var left = i - size < 0 ? int.MaxValue : values[i - size];
                if (left == maxs.Peek())
                {
                    maxs.Pop();
                }

                var right = values[i];
                if (right > maxs.Peek())
                {
                    maxs.Push(right);
                }

                min = this.Min(min, maxs.Peek());
            }

            return min;
        }
    }
}
