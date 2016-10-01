using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.DataStructures.Arrays;

namespace HackerRank.DataStructures.Stacks
{
    //Poisonous Plants
    //https://www.hackerrank.com/challenges/poisonous-plants
    //Instead try iterating from left to right over each plant, 
    //and calculate when each plant will die. To calculate when a plant will die, 
    //find the plant which can potentially kill it. This requires only the past information, 
    //by scanning towards the left. Using a stack here will help you with the leftwards scan.
    class A06 : IProgram
    {
        public void Run(string[] args)
        {
            //var pesticides = ArrayBuilder<int>.New(6, 5, 8, 4, 7, 10, 9);
            //var pesticides = ArrayBuilder<int>.New(20, 5, 6, 15, 2, 2, 17, 2, 11, 5, 14, 5, 10, 9, 19, 12, 5);
            //var pesticides = ArrayBuilder<int>.New(403, 1048, 15780, 14489, 15889, 18627, 13629, 13706, 16849, 13202, 10192, 17323, 4904, 6951, 16954, 5568, 4185, 7929, 8860, 14945, 3764, 4972, 13476, 14330, 1174, 18952, 10087, 10863, 9543, 12802, 1607, 9354, 13127, 92);
            //var pesticides = ArrayBuilder<int>.New(6, 5, 8, 4, 7, 10, 9, 5);
            var pesticides = ArrayBuilder<int>.New(6);
            int allAliveDayCount = DayCount(pesticides);
            Console.WriteLine(allAliveDayCount);
        }

        //HACK: Çok çok güzel bir daha çöz bakmadan
        private int DayCount(int[] input)
        {
            int[] days = new int[input.Length];
            Stack<int> potentialKillers = new Stack<int>();

            int min = int.MaxValue;
            for (int i = 0; i < input.Length; i++)
            {
                var current = input[i];
                if (current <= min)
                {
                    min = current;
                    days[i] = -1;
                    potentialKillers.Clear();
                    potentialKillers.Push(i);
                    continue;
                }

                var previous = input[i - 1];
                if (current > previous)
                {
                    days[i] = 1;
                }

                while (potentialKillers.Count != 0)
                {
                    var killerIndex = potentialKillers.Peek();
                    var killer = input[killerIndex];
                    if (current > killer)
                    {
                        break;
                    }

                    days[i] = this.Max(days[i], days[killerIndex] + 1);
                    potentialKillers.Pop();
                }   

                potentialKillers.Push(i);
            }

            var result = days.Max();
            return result == -1 ? 0 : result;
        }

    }
}
