using System;
using Common;

namespace CrackingTheCodingInterview.v5.DataStructures.ArraysAndStrings
{
    //Assume you have a method isSubstring which checks if one word is a substring of another.
    //Given two strings, si and s2, write code to check if s2 is a rotation of si using only one call to isSubstring
    //(e.g.,"waterbottle"is a rotation of "erbottlewat").
    public class A18: IProgram
    {
        public void Run(string[] args)
        {
            string input1 = "waterbottle";
            string input2 = "erbottlewat";

            bool rotated = IsRotated(input1, input2);
            Console.WriteLine(rotated);
        }

        private bool IsRotated(string input1, string input2)
        {
            string temp = input2 + input2;
            bool result = temp.Contains(input1);
            return result;
        }
    }
}
