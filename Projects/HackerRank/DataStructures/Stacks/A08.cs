using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Common.DataStructures.Arrays;

namespace HackerRank.DataStructures.Stacks
{
    class A08: IProgram
    {
        public void Run(string[] args)
        {
            //var header = InputParser.ParseLine();
            //var q = header[1];
            //var input = InputParser.OneDimension();

            var input = ArrayBuilder<int>.New(1, 8, 11, 23, 18, 2, 15, 30, 4, 5);
            var q = 2;
            //8 18 2 30 4
            //15
            //5 23 11 1 

            //var input = ArrayBuilder<int>.New(3, 4, 7, 6, 5);
            //var q = 1;
            //4 6 normal
            //3 7 5

            IList<int> primes = GeneratePrimes(q);
            PrintPiles(input, primes);
        }

        private void PrintPiles(int[] input, IList<int> primes)
        {
            IDictionary<int, Stack<int>> piles = new Dictionary<int, Stack<int>>();
            Stack<int> others = new Stack<int>();
            for (int i = input.Length - 1; i >= 0; i--)
            {
                var current = input[i];
                var sqrt = Math.Sqrt(current);
                var found = false;
                for (int j = 0; j < primes.Count; j++)
                {
                    var prime = primes[j];
                    if (current % prime != 0)
                    {
                        continue;
                    }

                    if (!piles.ContainsKey(prime))
                    {
                        piles.Add(prime, new Stack<int>());
                    }

                    var pile = piles[prime];
                    pile.Push(current);
                    found = true;
                    break;
                }

                if (!found)
                {
                    others.Push(current);
                }
            }

            for (int i = 0; i < primes.Count; i++)
            {
                var prime = primes[i];
                if (!piles.ContainsKey(prime))
                {
                    continue;
                }

                var pile = piles[prime];
                if (i%2 == 0)
                {
                    PrintNormal(pile);
                }
                else
                {
                    PrintReverse(pile);
                }
            }

            if (primes.Count % 2 == 1)
            {
                PrintNormal(others);
            }
            else
            {
                PrintReverse(others);
            }
        }

        private void PrintReverse(Stack<int> pile)
        {
            if (pile.Count == 0)
            {
                return;
            }

            var value = pile.Pop();
            PrintReverse(pile);
            Console.WriteLine(value);
        }

        private void PrintNormal(Stack<int> pile)
        {
            if (pile.Count == 0)
            {
                return;
            }

            var value = pile.Pop();
            Console.WriteLine(value);
            PrintNormal(pile);
        }

        private IList<int> GeneratePrimes(int count)
        {
            if (count == 1)
            {
                return new[] { 2 }.ToList();
            }

            var previousPrimes = GeneratePrimes(count - 1);
            if (count == 2)
            {
                previousPrimes.Add(3);
                return previousPrimes;
            }

            var last = previousPrimes.Last();

            for (int current = last + 2; current < int.MaxValue; current+=2)
            {
                var sqrt = Math.Sqrt(current);
                foreach (var prime in previousPrimes)
                {
                    if (prime > sqrt)
                    {
                        previousPrimes.Add(current);
                        return previousPrimes;
                    }

                    if (current%prime == 0)
                    {
                        break;
                    }
                }
            }

            return null;
        }
    }
}
