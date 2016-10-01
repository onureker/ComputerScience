using System;
using Common;
using Common.DataStructures.LinkedLists;

namespace CrackingTheCodingInterview.v5.DataStructures.LinkedLists
{
    //Implement a function to check if a linked list is a palindrome.
    public partial class A27: IProgram
    {
        public void Run(string[] args)
        {
            var head = Nodes.Build(1, 2, 3, 0, 3, 2, 1);
            //var head = Nodes.Build(1, 2, 3, 3, 2, 1);
            //bool palindrome = IterativeAnswer(head);
            bool palindrome = RecursiveAnswer(head);
            Console.WriteLine(palindrome);
        }

    }
}
