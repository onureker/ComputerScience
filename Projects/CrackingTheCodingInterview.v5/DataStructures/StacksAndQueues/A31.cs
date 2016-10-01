using System;
using System.Linq;
using Common;

namespace CrackingTheCodingInterview.v5.DataStructures.StacksAndQueues
{
    public class A31: IProgram
    {
        //TODO: Flxible size olarak nasıl yapılır?
        public void Run(string[] args)
        {
            NStack nStack = new NStack(3);
            var isEmpty = nStack.IsEmpty(0);
            nStack.Push(0, 1);
            var isEmpty2 = nStack.IsEmpty(0);
            var pop = nStack.Pop(0);
        }

        public class NStack
        {
            private readonly int stackCount;
            private readonly int[] stackPointers;
            private readonly int[] backingStore;

            public NStack(int stackCount)
            {
                this.stackCount = stackCount;
                this.stackPointers = Enumerable.Range(0, stackCount).Select(x => x - stackCount).ToArray();
                this.backingStore = new int[stackCount * 1000];
            }

            public void Push(int stack, int value)
            {
                int stackPointer = stackPointers[stack];
                stackPointer += stackCount;
                if (stackPointer > backingStore.Length)
                {
                    throw  new Exception("Stack full: Stack = " + stack);
                }

                backingStore[stackPointer] = value;
                stackPointers[stack] = stackPointer;
            }

            public int Peek(int stack)
            {
                int stackPointer = stackPointers[stack];
                if (stackPointer < 0)
                {
                    throw new Exception("Stack empty: Stack = " + stack);
                }

                var result = backingStore[stackPointer];
                return result;
            }

            public int Pop(int stack)
            {
                var result = Peek(stack);
                int stackPointer = stackPointers[stack];
                stackPointer -= stackCount;
                stackPointers[stack] = stackPointer;
                return result;
            }

            public bool IsEmpty(int stack)
            {
                int stackPointer = stackPointers[stack];
                return stackPointer < 0;
            }
        }
    }
}
