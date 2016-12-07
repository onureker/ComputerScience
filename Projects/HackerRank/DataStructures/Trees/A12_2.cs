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
    public static class Tep
    {
        public static string ReverseStr(this string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }

    //Square-Ten Tree
    //https://www.hackerrank.com/challenges/square-ten-tree
    class A12_2 : IProgram
    {
        /*
        [42; 1024] =
        [42; 42] + [43; 43] + ... + [50; 50] (9 of level 0) +
        [51; 60] + [61; 70] + ... [91; 100] (5 of level 1) +
        [101; 200] + [201; 300] + ... + [901; 1000] (9 of level 2) +
        [1001; 1010] + [1011; 1020] (2 of level 1) +
        [1021; 1021] + [1022; 1022] + [1023;1023] + [1024; 1024] (4 of level 0)
        */

        static IEnumerable<string> Split(string str, int chunkSize)
        {
            var reversed = str.ReverseStr();
            return Enumerable.Range(0, str.Length / chunkSize).Select(i => reversed.Substring(i * chunkSize, chunkSize).ReverseStr().ToString());
        }

        public void Run(string[] args)
        {
            var textReader = Console.In;
            //int left = textReader.ReadLine().ParseToIntArray()[0];
            //int right = textReader.ReadLine().ParseToIntArray()[0];

            //int left = 42; int right = 1024;
            //int left = 1; int right = 10;
            //int left = 1; int right = 100;
            //int left = 1; int right = 1000;

            //long left = 4120093975;
            //long right = 6130138378;

            var leftString  = "4340373905259997502755913363205488174937147740987507442520118970518363923127631374815734377755104515";
            var rightString = "9579845296932948870588654492426008828709463909124269322272190994661793582999050921717348434654712607";

            var s = 7;
            var leftStrings = Split(leftString, s).ToArray();
            var rightStrings = Split(rightString, s).ToArray();

            int max = Math.Max(leftStrings.Length, rightStrings.Length);

            int level = 0;
            List<Tuple<int, long>> result = new List<Tuple<int, long>>();

            for (int i = 0; i < max; i++)
            {
                var left = long.Parse(leftStrings[i]);
                var right = long.Parse(rightStrings[i]);

                List<Tuple<int, long>> current = Go(left - 1, right, 0);
                result.AddRange(current);
            }


            /*
4340373905259997502755913363205488174937147740987507442520118970518363923127631374815734377755104515
9579845296932948870588654492426008828709463909124269322272190994661793582999050921717348434654712607

14
0 6
1 8
2 54
3 4489
4 42656222
5 3607687236862518
6 50628522590124925574798810294816
7 523947139167295136783274112922052064
6 87094639091242693222721909946617
5 9358299905092171
4 73484346
3 5471
2 26
0 7
 */

            /*
            int left = 4120093975;
            int right = 6130138378;
            9
            0 6
            1 2
            2 60
            3 7990
            4 19
            3 3013
            2 83
            1 7
            0 8
            */
            //int left = 2; int right = 1000;

            //List<Tuple<int, long>> result = Go(left-1, right, 0);

            Console.WriteLine(result.Count);
            result.Select(tuple => tuple.Item1 + " " + tuple.Item2 ).ToList().ForEach(Console.WriteLine);
        }

        private List<Tuple<int, long>> Go(long from, long to, int level)
        {
            List<Tuple<int, long>> result = new List<Tuple<int, long>>();
            if (from == to)
            {
                return result;
            }

            long temp = (long)(Math.Pow(2, level+1) - Math.Pow(2, level));
            long nextStepLength = (long)Math.Pow(10, temp);

            var fromMod = from%nextStepLength;
            var fromUpper = fromMod == 0 ? from : from - fromMod + nextStepLength;
            long fromStepIndex = from/nextStepLength;

            var toMod = to%nextStepLength;
            var toLower = toMod == 0 ? to : to - toMod;
            long toStepIndex = to/nextStepLength;

            if (fromStepIndex == toStepIndex)
            {
                result.Add(GoLine(from, to, level));
                return result;
            }

            if (from != fromUpper)
            {
                result.Add(GoLine(from, fromUpper, level));
            }

            result.AddRange(Go(fromUpper, toLower, level + 1));

            if (to != toLower)
            {
                result.Add(GoLine(toLower, to, level));
            }

            return result;
        }

        private Tuple<int, long> GoLine(long from, long to, int level)
        {
            long temp = (long) (Math.Pow(2, level) - Math.Pow(2, level - 1));
            long stepLength = (long)Math.Pow(10, temp);
            var stepCount = (to - @from) / stepLength;

            return new Tuple<int, long>(level, stepCount);
        }

    }
}
