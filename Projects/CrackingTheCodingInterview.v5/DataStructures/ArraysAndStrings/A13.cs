using System;
using System.Linq;
using Common;

namespace CrackingTheCodingInterview.v5.DataStructures.ArraysAndStrings
{
    public class A13: IProgram
    {
        public void Run(string[] args)
        {
            string input1 = "OnurEker".ToUpper();
            string input2 = "ErekRuno".ToUpper();

            bool result1 = IsPermutationWithSort(input1, input2);
            Console.WriteLine(result1);

            bool result2 = IsPermutationWithCharCount(input1, input2);
            Console.WriteLine(result2);
        }

        private bool IsPermutationWithSort(string input1, string input2)
        {
            if (input1.Length != input2.Length)
            {
                return false;
            }

            var ordered1 = input1.OrderBy(c => c);
            var ordered2 = input2.OrderBy(c => c);
            return ordered1.SequenceEqual(ordered2);
        }

        private bool IsPermutationWithCharCount(string input1, string input2)
        {
            if (input1.Length != input2.Length)
            {
                return false;
            }

            int[] characterCounts = new int['Z' - 'A' + 1];
            foreach (var character in input1)
            {
                int index = character - 'A';
                characterCounts[index]++;
            }

            foreach (var character in input2)
            {
                int index = character - 'A';
                if (characterCounts[index] == 0)
                {
                    return false;
                }

                characterCounts[index]--;
            }

            return true;
        }
    }
}
