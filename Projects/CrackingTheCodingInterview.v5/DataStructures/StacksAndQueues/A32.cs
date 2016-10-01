using System;
using System.Collections.Generic;
using Common;

namespace CrackingTheCodingInterview.v5.DataStructures.StacksAndQueues
{
    public class A32: IProgram
    {
        public class CustomStack
        {
            private readonly Stack<int> values;
            private readonly Stack<int> mins;

            public CustomStack()
            {
                values = new Stack<int>();
                mins = new Stack<int>();
                mins.Push(int.MaxValue);
            }

            public void Push(int value)
            {
                values.Push(value);
                if (mins.Peek() < value)
                {
                    return;
                }

                mins.Push(value);
            }

            public int Pop()
            {
                var value = values.Pop();
                if (mins.Peek() == value)
                {
                    mins.Pop(); 
                }

                return value;
            }

            public int Min()
            {
                return mins.Peek();
            }
        }

        public void Run(string[] args)
        {
            CustomStack customStack = new CustomStack();
            customStack.Push(5);
            Console.WriteLine(customStack.Min());
            customStack.Push(3);
            Console.WriteLine(customStack.Min());
            customStack.Pop();
            Console.WriteLine(customStack.Min());
            customStack.Push(7);
            Console.WriteLine(customStack.Min());
            customStack.Pop();
            Console.WriteLine(customStack.Min());
        }
    }
}
