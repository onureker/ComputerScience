using System;
using System.Collections.Generic;
using Common;
using Common.DataStructures.Arrays;

namespace HackerRank.DataStructures.Arrays
{
    class A05: IProgram
    {
        public void Run(string[] args)
        {
            var words = ArrayBuilder<string>.New("aba", "baba", "aba", "xzxb");
            var queries = ArrayBuilder<string>.New("aba", "xzxb", "ab");

            int[] counts = GetCounts(words, queries);
            foreach (int count in counts)
            {
                Console.WriteLine(count);
            }
        }

        private int[] GetCounts(string[] words, string[] queries)
        {
            IDictionary<string, int> map = new Dictionary<string, int>();
            foreach (var currentWord in words)
            {
                int count = map.ContainsKey(currentWord) ? map[currentWord] : 0;
                map[currentWord] = ++count;
            }

            int[] result = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                var query = queries[i];
                int count = map.ContainsKey(query) ? map[query] : 0;
                result[i] = count;
            }

            return result;
        }

    }
}
