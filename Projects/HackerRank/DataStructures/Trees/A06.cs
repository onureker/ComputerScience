using System;
using System.Collections.Generic;
using Common;
using Common.DataStructures.Trees;
using Common.Utility.Java;

namespace HackerRank.DataStructures.Trees
{
    //Tree: Level Order Traversal
    //https://www.hackerrank.com/challenges/tree-level-order-traversal
    class A06: IProgram
    {
        public void Run(string[] args)
        {
            var root = TreeBuilder.Parse("3(5(1,4),2(6))");
            var result = LevelOrderText(root);
            Console.WriteLine(result);
        }

        private string LevelOrderText(Node root)
        {
            String result = "";
            Queue<Node> queue = new global::Common.Utility.Java.LinkedList<Node>();
            queue.add(root);

            while (queue.size() != 0)
            {
                Node current = queue.poll();
                result += current.data + " ";

                if (current.left != null)
                {
                    queue.add(current.left);
                }

                if (current.right != null)
                {
                    queue.add(current.right);
                }
            }

            return result;
        }

    }
}
