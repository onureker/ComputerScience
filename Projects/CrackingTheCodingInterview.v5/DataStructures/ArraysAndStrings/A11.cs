using System;
using System.Collections.Generic;
using Common;

namespace CrackingTheCodingInterview.v5.DataStructures.ArraysAndStrings
{
    public class A11 : IProgram
    {
        //Implement an algorithm to determine if a string has all unique characters.What
        //if you cannot use additional data structures?
        public void Run(string[] args)
        {
            string input = "AZOnurEker".ToUpper();
            bool result1 = WithList(input);
            Console.WriteLine(result1);

            bool result2 = WithFixArray(input);
            Console.WriteLine(result2);

            bool result3 = WithSingleInt(input);
            Console.WriteLine(result3);
        }

        private bool WithSingleInt(string input)
        {
            int existsMask = 0;
            char[] charArray = input.ToCharArray();
            foreach (var currentChar in charArray)
            {
                int index = currentChar - 'A';
                int mask = 1 << index;
                bool exists = (existsMask & mask) == mask; // bool exists = (existsMask & mask) > 0 da olabilir
                if (exists)
                {
                    return false;
                }

                existsMask = existsMask | mask;
            }

            return true;
        }

        private bool WithFixArray(string input)
        {
            int length = 'Z' - 'A' + 1;
            bool[] existsArray = new bool[length];

            char[] charArray = input.ToCharArray();
            foreach (var currentChar in charArray)
            {
                int index = currentChar - 'A';
                if (existsArray[index])
                {
                    return false;
                }

                existsArray[index] = true;
            }

            return true;
        }

        private bool WithList(string input)
        {
            IList<char> existList = new List<char>();
            char[] charArray = input.ToCharArray();
            foreach (var currentChar in charArray)
            {
                if (existList.Contains(currentChar))
                {
                    return false;
                }

                existList.Add(currentChar);
            }

            return true;
        }
    }
}
