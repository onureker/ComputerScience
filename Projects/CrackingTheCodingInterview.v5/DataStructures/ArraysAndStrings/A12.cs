using System;
using Common;

namespace CrackingTheCodingInterview.v5.DataStructures.ArraysAndStrings
{
    public class A12: IProgram
    {
        public void Run(string[] args)
        {
            string input = "Onur".ToUpper();
            string output1 = ReverseWithNDivide2(input);
            Console.WriteLine(output1);
        }

        private string ReverseWithNDivide2(string input)
        {
            char[] charArray = input.ToCharArray();
            for (int i = 0; i < charArray.Length/2; i++)
            {
                this.Swap(ref charArray[i], ref charArray[charArray.Length - i - 1]);
            }

            return new string(charArray);
        }
    }
}
