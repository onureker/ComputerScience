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
    // ReSharper disable once InconsistentNaming
    class A04_LeftRotation_InPlace : IProgram
    {
        public void Run(string[] args)
        {
            var input = ArrayBuilder<int>.New(1, 2, 3, 4, 5);
            input.Dump();
            var result = RotateLeft(input, 3);
            result.Dump();
        }

        //TODO: Daha güzel yapılabilir
        private int[] RotateLeft(int[] input, int rotateCount)
        {
            int targetIndex = 0;
            int buff = input[0];
            for (int i = 0; i < input.Length; i++)
            {
                int sourceIndex = (rotateCount + targetIndex) % input.Length;
                input[targetIndex] = input[sourceIndex];
                targetIndex = sourceIndex;
            }

            int x = (0 - rotateCount + input.Length) % input.Length;
            input[x] = buff;
            return input;
        }
    }
}
