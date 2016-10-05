using System.Collections.Generic;
using System.Linq;
using Common;

namespace CrackingTheCodingInterview.v5.DataStructures.StacksAndQueues
{
    //Imagine a (literal) stack of plates. If the stack gets too high, it might topple.
    //Therefore, in real life, we would likely start a new stack when the previous stack exceeds somethreshold.
    //Implement a data structureSetOf Stacks that mimics this.
    //SetOf Stacks should be composed of several stacks and should create a new stack once the previous one exceedscapacity.
    //SetOf Stacks.push() and SetOf Stacks.pop() should behave identically to a single stack
    //(that is, pop should return the same values as it would if there were just a single stack).
    public class A33: IProgram
    {
        public class SetOfStack
        {
            private Stack<int> currentStack;
            private readonly int capacity;
            private readonly IList<Stack<int>> stacks;

            public SetOfStack(int capacity)
            {
                this.capacity = capacity;
                this.stacks = new List<Stack<int>>();
            }

            public void Push(int value)
            {
                if (currentStack == null || currentStack.Count == capacity)
                {
                    currentStack = new Stack<int>(capacity);
                    stacks.Add(currentStack);
                }

                currentStack.Push(value);
            }

            public int Pop()
            {
                if (currentStack.Count == 0)
                {
                    stacks.Remove(currentStack);
                    currentStack = stacks.Last();
                }

                return currentStack.Pop();
            }

            public int Peek()
            {
                return currentStack.Peek();
            }
        }

        public void Run(string[] args)
        {
            SetOfStack setOfStack = new SetOfStack(3);
            setOfStack.Push(1);
            setOfStack.Push(2);
            setOfStack.Push(3);
            setOfStack.Push(4);
            setOfStack.Pop();
            setOfStack.Pop();
            setOfStack.Pop();
        }
    }
}
