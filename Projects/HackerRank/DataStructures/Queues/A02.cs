using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.DataStructures.Arrays;
using HackerRank.Common;

namespace HackerRank.DataStructures.Queues
{
    //Down to Zero II
    //https://www.hackerrank.com/challenges/down-to-zero-ii
    class A02 : IProgram
    {
        //HACK: Güzel zekice
        public void Run(string[] args)
        {
            var backingStore = BuildBackingStore();

            //var file = this.ReadFile("A02.input.txt");
            //InputParser.ParseHeader(file);
            //var inputs = InputParser.MultiLine(file).Select(Line.ToInt);

            var inputs = ArrayBuilder<int>.New(0);

            foreach (var input in inputs)
            {
                int output = DownToZero(input, backingStore);
                Console.WriteLine(output);
            }
            //Test(backingStore);
        }

        public void Test(IDictionary<int, int> backingStore)
        {
            var inputText = this.ReadFile("A02.input.txt");
            var count = inputText.ReadLine().ParseToIntArray()[0];
            var inputs = inputText.ReadLines(count).Select(Extensions.ToInt).ToList();

            var outputText = this.ReadFile("A02.output.txt");
            var outputs = outputText.ReadLines(count).Select(Extensions.ToInt).ToList();


            //var inputs = ArrayBuilder<int>.New(812849);

            for (int i = 0; i < inputs.Count; i++)
            {
                var input = inputs[i];
                int actual = DownToZero(input, backingStore);
                var output = outputs[i];

                if (actual != output)
                {
                    Debugger.Break();
                }
            }
        }

        private IDictionary<int, int> BuildBackingStore()
        {
            IDictionary<int, int> backingStore = new Dictionary<int, int>();
            for (int i = 0; i < 1000000; i++)
            {
                var currentResult = DownToZero(i, backingStore);
                var multipliedResult = currentResult + 1;
                backingStore[i] = currentResult;

                for (int j = 2; j <= i; j++)
                {
                    int multiplied = i*j;
                    if (multiplied > 1000000)
                    {
                        break;
                    }

                    if (!backingStore.ContainsKey(multiplied))
                    {
                        backingStore[multiplied] = multipliedResult;
                        continue;
                    }

                    backingStore[multiplied] = this.Min(multipliedResult, backingStore[multiplied]);
                }
            }
            return backingStore;
        }

        private int DownToZero(int input, IDictionary<int, int> backingStore)
        {
            if (input == 0)
            {
                return 0;
            }

            var byPrevious = backingStore[input - 1] + 1;
            if (!backingStore.ContainsKey(input))
            {
                return byPrevious;
            }

            var result = this.Min(backingStore[input], byPrevious);
            return result;
        }

    }
}
