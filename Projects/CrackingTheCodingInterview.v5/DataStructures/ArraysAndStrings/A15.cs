using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace CrackingTheCodingInterview.v5.DataStructures.ArraysAndStrings
{
    public class A15: IProgram
    {
        private class Entry
        {
            public char Character { get; set; }
            public int Length { get; set; }

            public Entry(char character, int length)
            {
                Character = character;
                Length = length;
            }
        }

        public void Run(string[] args)
        {
            string input = "aabcccccaaa";
            string compressed = Compress(input);
            Console.WriteLine(compressed);
        }

        private string Compress(string input)
        {
            IList<Entry> entries = GetEntries(input);

            int compressedLength = entries.Sum(entry => entry.Length.ToString().Length + 1);
            if (input.Length < compressedLength)
            {
                return input;
            }

            string compressed = string.Join(string.Empty, entries.Select(entry => entry.Character.ToString() + entry.Length));
            return compressed;
        }

        private static IList<Entry> GetEntries(string input)
        {
            char lastChar = input[0];
            int count = 1;
            IList<Entry> entries = new List<Entry>();
            for (int i = 1; i < input.Length; i++)
            {
                char current = input[i];
                if (current == lastChar)
                {
                    count++;
                    continue;
                }

                Entry entry = new Entry(lastChar, count);
                entries.Add(entry);

                lastChar = current;
                count = 1;
            }

            Entry lastEntry = new Entry(lastChar, count);
            entries.Add(lastEntry);
            return entries;
        }
    }
}
