using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.DataStructures.LinkedLists;

namespace HackerRank.DataStructures.LinkedLists
{
    //Find Merge Point of Two Lists
    //https://www.hackerrank.com/challenges/find-the-merge-point-of-two-joined-linked-lists
    class A13: IProgram
    {
        public void Run(string[] args)
        {
            var headA = Nodes.Build(1, 2, 3);
            var node3 = headA.Lookup(3);
            var headB = Nodes.Build(4);
            headB.Append(node3);
            int result = FindMergeNode(headA, headB);
            Console.WriteLine(result);
        }

        //HACK: Mükemmel
        private int FindMergeNode(Node<int> headA, Node<int> headB)
        {
            var currentA = headA;
            var currentB = headB;

            //Do till the two nodes are the same
            while (currentA != currentB)
            {
                //If you reached the end of one list start at the beginning of the other one
                //currentA
                currentA = currentA.Next ?? headB;
                //currentB
                currentB = currentB.Next ?? headA;
            }
            return currentB.Data;
        }

    }
}
