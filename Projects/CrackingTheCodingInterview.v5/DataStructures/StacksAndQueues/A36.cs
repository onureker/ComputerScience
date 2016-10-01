using System.Collections.Generic;
using Common;

namespace CrackingTheCodingInterview.v5.DataStructures.StacksAndQueues
{
    public class A36: IProgram
    {
        public void Run(string[] args)
        {
            Stack<int> source = new Stack<int>();
            source.Push(3);
            source.Push(7);
            source.Push(1);
            source.Push(9);

            Stack<int> target = new Stack<int>();

            while (source.Count != 0)
            {
                var value = source.Pop();

                int count = 0;
                while (target.Count != 0 && target.Peek() > value)
                {
                    source.Push(target.Pop());
                    count++;
                }

                target.Push(value);

                //HACK: Aslında aşağıdaki koda ihtiyaç yok çünkü while zaten atacak tekrar içeri
                /*
                for (int i = 0; i < count; i++)
                {
                    target.Push(source.Pop());
                }
                */
            }
        }
    }
}
