using System.Collections.Generic;
using Common;

namespace CrackingTheCodingInterview.v5.DataStructures.StacksAndQueues
{
    //Implement a MyQueue class which implements a queue using two stacks.
    public class A35: IProgram
    {
        public class MyQueue
        {
            private readonly Stack<int> pushStack;
            private readonly Stack<int> popStack;
            public MyQueue()
            {
                pushStack = new Stack<int>();
                popStack = new Stack<int>();
            }

            public void Push(int value)
            {
                pushStack.Push(value);
            }

            public int Pop()
            {
                //HACK: Güzel takla, sadece popStack boşlınca tekrar bufferlıyor..
                if (popStack.Count == 0)
                {
                    while (pushStack.Count != 0)
                    {
                        var current = pushStack.Pop();
                        //Burada empty kontrol
                        popStack.Push(current);
                    }
                }

                //Burada empty kontrol
                var result = popStack.Pop();
                return result;
            }
        }

        public void Run(string[] args)
        {
            MyQueue myQueue = new MyQueue();
            myQueue.Push(1);
            myQueue.Push(2);
            myQueue.Push(3);
            myQueue.Pop();
            myQueue.Push(4);
            myQueue.Push(5);
            myQueue.Pop();
            myQueue.Pop();
            myQueue.Pop();
            myQueue.Pop();
        }
    }
}
