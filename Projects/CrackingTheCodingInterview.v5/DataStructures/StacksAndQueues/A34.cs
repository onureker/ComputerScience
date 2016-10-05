using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace CrackingTheCodingInterview.v5.DataStructures.StacksAndQueues
{

    //In the classic problem of the Towers of Hanoi, you have 3 towers and Ndisks of
    //different sizes which can slide onto any tower.The puzzle starts with diskssorted
    //in ascending order of size from top to bottom (i.e., each disk sits on top of an
    //even larger one). You have the following constraints:
    //(1) Only one disk can be moved at a time.
    //(2) A disk is slid off the top of one tower onto the next tower.
    //(3) A disk can only be placed on top of a larger disk.
    //Write a program to move the disksfrom the first tower to the last using stacks
    public class A34: IProgram
    {
        private readonly IDictionary<int, Stack<int>> towers;

        public A34()
        {
            towers = new Dictionary<int, Stack<int>>();
            towers.Add(0, new Stack<int>());
            towers.Add(1, new Stack<int>());
            towers.Add(2, new Stack<int>());
        }

        public void Run(string[] args)
        {
            int count = 20;
            Enumerable.Range(0, count).Select(i => count - i).ToList().ForEach(i => towers[0].Push(i));
            Move(0, 2, count);
        }

        public void Move(int from, int to, int diskCount)
        {
            if (diskCount == 1)
            {
                MoveDisk(from, to);
                return;
            }

            int other = 3 - from - to;
            Move(from, other, diskCount-1);
            MoveDisk(from, to);
            Move(other, to, diskCount-1);
        }

        private void MoveDisk(int @from, int to)
        {
            var current = towers[@from].Pop();
            towers[to].Push(current);
            char fromString = (char) (65 + from);
            char toString = (char)(65 + to);
            Console.WriteLine($"Move disk {current} from {fromString} to {toString}");
        }
    }
}
