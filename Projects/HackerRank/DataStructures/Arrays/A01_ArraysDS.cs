using System;
using Common;
using Common.DataStructures.Arrays;

namespace HackerRank.DataStructures.Arrays
{
    //Arrays - DS
    //https://www.hackerrank.com/challenges/arrays-ds
    // ReSharper disable once InconsistentNaming
    class A01_ArraysDS : IProgram
    {
        public void Run(string[] args)
        {
            var ints = ArrayBuilder<int>.New(1, 4, 3, 2);
            ints.Dump();

            for (int i = ints.Length-1; i >= 0 ; i--)
            {
                Console.Write(ints[i] + " ");
            }
        }
    }
}
