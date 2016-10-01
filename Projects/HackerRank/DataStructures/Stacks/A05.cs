using System;
using System.Linq;
using Common;
using Common.DataStructures.Arrays;

namespace HackerRank.DataStructures.Stacks
{
    //Equal Stacks
    //https://www.hackerrank.com/challenges/equal-stacks
    class A05 : IProgram
    {
        public void Run(string[] args)
        {
            var h1 = ArrayBuilder<int>.New(3, 2, 1, 1, 1);
            var h2 = ArrayBuilder<int>.New(4, 3, 2);
            var h3 = ArrayBuilder<int>.New(1, 1, 4, 1);

            var s1 = FindEqualStackHeight(h1, h2, h3);

            Console.WriteLine(s1);
        }

        private int FindEqualStackHeight(int[] h1, int[] h2, int[] h3)
        {
            int s1 = h1.Sum();
            int s2 = h2.Sum();
            int s3 = h3.Sum();

            int i1 = 0;
            int i2 = 0;
            int i3 = 0;

            while (s1 != s2 || s1 != s3)
            {
                if (s1 >= s2 && s1 >= s3)
                {
                    s1 -= h1[i1];
                    i1++;
                    continue;
                }

                if (s2 >= s1 && s2 >= s3)
                {
                    s2 -= h2[i2];
                    i2++;
                    continue;
                }

                if (s3 >= s1 && s3 >= s2)
                {
                    s3 -= h3[i3];
                    i3++;
                    continue;
                }
            }
            return s1;
        }
    }
}
