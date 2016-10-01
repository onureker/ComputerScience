using System;
using Common;

namespace CrackingTheCodingInterview.v5.DataStructures.ArraysAndStrings
{
    public class A14: IProgram
    {
        public void Run(string[] args)
        {
            string input  = "Mr John Smith    ";
            string output = ReplaceSpace(input);
            Console.WriteLine(output);
        }

        private string ReplaceSpace(string input)
        {
            int targetIndex = input.Length - 1;
            bool started = false;
            char[] charArray = input.ToCharArray();

            for (int i = charArray.Length - 1; i >= 0; i--)
            {
                char currentCharacter = charArray[i];
                if (currentCharacter == ' ' && !started)
                {
                    continue;
                }

                started = true;
                if (currentCharacter != ' ')
                {
                    charArray[targetIndex--] = currentCharacter;
                    continue;
                }

                charArray[targetIndex--] = '0';
                charArray[targetIndex--] = '2';
                charArray[targetIndex--] = '%';
            }

            return new string(charArray);
        }
    }
}
