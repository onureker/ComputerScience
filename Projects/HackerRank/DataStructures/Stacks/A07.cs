using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.DataStructures.Arrays;
using HackerRank.Common;

namespace HackerRank.DataStructures.Stacks
{
    //AND xor OR
    //https://www.hackerrank.com/challenges/and-xor-or
    public class A07: IProgram
    {
        public void Run(string[] args)
        {
            //var input = InputParser.OneDimension();
            var input = ArrayBuilder<int>.New(9, 6, 3, 5, 4, 2);
            //var input = ArrayBuilder<int>.New(47606126, 65484553, 142643, 35352821, 26622058, 5603080, 7296801, 53938188, 34750256, 97196502);
            int max = FindMax(input);
            Console.WriteLine(max);
        }

        //HACK: Çok güzel
        //Stack soldan sağa giderken küçükten büyüğe doğru olan sıralamayı tutuyor. yani 3-5, 3-4, 2 gibi
        //Iterasyon sırasında daha küçük bir sayı bulursa o küçüğe kadar olan stack'i boşaltıyor.
        //Çünkü FACT: En küçük sayı sola doğru baktığında daha küçüğü olana kadar partitondır.
        private int FindMax(int[] input)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(input[0]);
            int result = 0;

            for (int i = 1; i < input.Length; i++)
            {
                int current = input[i];
                while (stack.Count != 0)
                {
                    var top = stack.Peek();
                    int calculation = Calculate(current, top);
                    result = calculation > result ? calculation : result;

                    if (top <= current)
                    {
                        break;
                    }

                    stack.Pop();
                }

                stack.Push(current);
            }

            return result;
        }

        private int Calculate(int value1, int value2)
        {
            return value1 ^ value2;
        }
    }
}
