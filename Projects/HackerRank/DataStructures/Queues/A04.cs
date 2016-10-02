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

            //var values = ArrayBuilder<int>.New(3, 2, 1, 4, 5);
            //var values = ArrayBuilder<int>.New(1, 2, 3, 4, 5);
            //var d = 2;

            var values = ArrayBuilder<int>.New(176641, 818878, 590130, 846132, 359913, 699520, 974627, 806346, 343832, 619769, 760242, 693331, 832192, 775549, 353117, 23950, 496548, 183204, 971799, 393071, 727476, 351337, 811496, 24595, 417701, 664960, 745806, 538176, 230403, 942316, 21481, 605695, 598531, 651683, 558460, 583357, 530911, 721611, 308228, 724620, 429167, 909353, 330152, 116815, 986067, 713467, 906132, 428600, 927889, 567272, 647109, 992614, 747948, 192884, 879696, 262543, 782487, 829272, 470060, 427956, 751730, 597177, 870616, 754791, 421830, 11676, 425656, 841955, 693419, 462693, 245403, 192649, 750201, 180732, 17450, 44723, 527618, 174579, 515786, 444844, 210843, 563425, 809540, 752036, 608529, 748313, 667439, 255643, 387412, 320353, 704213, 755272, 267902, 657989, 651762, 325654, 582887, 382501, 715426, 897450);
            var d = 78;

            int result = FindMinOfMaxs(values, d);
            Console.WriteLine(result);
        }

        private int FindMinOfMaxs(int[] values, int size)
        {
            Queue<int> max1 = new Queue<int>();
            Queue<int> max2 = new Queue<int>();
            values.Take(size).ToList().ForEach(i => Enqueue(i, max1, max2));
            int min = max1.Peek();

            for (int i = size; i < values.Length; i++)
            {
                var left = values[i - size];
                Dequeue(left, max1, max2);

                var right = values[i];
                Enqueue(right, max1, max2);

                min = this.Min(min, max1.Peek());
            }

            return min;
        }

        private void Dequeue(int value, Queue<int> max1, Queue<int> max2)
        {
            if (max1.Count == 0 || value != max1.Peek())
            {
                return;
            }

            max1.Dequeue();

            if (max2.Count == 0)
            {
                return;
            }

            var transferred = max2.Dequeue();
            max1.Enqueue(transferred);
        }

        private void Enqueue(int value, Queue<int> max1, Queue<int> max2)
        {
            int max1Value = max1.Count == 0 ? int.MinValue : max1.Peek();
            if (value > max1Value)
            {
                max1.Clear();
                max2.Clear();
                max1.Enqueue(value);
                return;
            }

            int max2Value = max2.Count == 0 ? int.MinValue : max2.Peek();
            if (value > max2Value)
            {
                max2.Clear();
                max2.Enqueue(value);
            }
        }
    }
}
