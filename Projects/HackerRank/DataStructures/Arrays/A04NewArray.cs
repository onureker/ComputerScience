using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.DataStructures.Arrays;

namespace HackerRank.DataStructures.Arrays
{
    //Left Rotation
    //https://www.hackerrank.com/challenges/array-left-rotation
    class A04NewArray : IProgram
    {
        public void Run(string[] args)
        {
            var input = ArrayBuilder<int>.New(1, 2, 3, 4, 5);
            input.Dump();
            var result = RotateLeft(input, 3);
            result.Dump();
        }

        private int[] RotateLeft(int[] input, int rotateCount)
        {
            int[] result = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                int sourceIndex = (i + rotateCount) % input.Length;
                result[i] = input[sourceIndex];
            }

            return result;
        }

    }
}
