using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.DataStructures.Trees;
using HackerRank.Common;

namespace HackerRank.DataStructures.Trees
{
    //Swap Nodes [Algo]
    //https://www.hackerrank.com/challenges/swap-nodes-algo
    public class A10: IProgram
    {
        public void Run(string[] args)
        {
            var reader = Console.In;
            var inputCount = reader.ReadLine().ParseToIntArray()[0];
            var inputValues = reader.ReadLines(inputCount).Select(Extensions.ParseToIntArray).ToList();
            var swapCount = reader.ReadLine().ParseToIntArray()[0];
            var swaps = reader.ReadLines(swapCount).Select(Extensions.ToInt).ToList();

            var root = BuildTree(inputValues);
            foreach (var swapHeight in swaps)
            {
                root = Swap(root, swapHeight);
                root.InOrder(x => Console.Write(x.Data + " "));
                Console.WriteLine();
            }

            /*
            //var root = TreeBuilder.Parse("1(2,3)");
            //var root = TreeBuilder.Parse("1(2(,4),3(,5))");
            //var root = TreeBuilder.Parse("1(2(4(6(,9))),3(5(7,8(10,11))))");
            root = Swap(root, 2);
            root.InOrder(x => Console.Write(x.Data + " "));
            Console.WriteLine();
            root = Swap(root, 4);
            root.InOrder(x => Console.Write(x.Data + " "));
            */
        }

        private Node BuildTree(List<int[]> inputValues)
        {
            Node root = new Node(1);
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            Queue<int[]> values = new Queue<int[]>(inputValues);

            while (values.Count != 0)
            {
                var current = queue.Dequeue();
                var children = values.Dequeue();

                if (children[0] != -1)
                {
                    var newNode = new Node(children[0]);
                    current.Left = newNode;
                    queue.Enqueue(newNode);
                }

                if (children[1] != -1)
                {
                    var newNode = new Node(children[1]);
                    current.Right = newNode;
                    queue.Enqueue(newNode);
                }
            }

            return root;
        }

        private Node Swap(Node root, int height)
        {
            Node result = Swap(root, height, 1);
            return result;
        }

        private Node Swap(Node root, int height, int currentHeight)
        {
            if (root == null)
            {
                return null;
            }

            bool swap = currentHeight%height == 0;

            if (swap)
            {
                var temp = root.Left;
                root.Left = root.Right;
                root.Right = temp;
            }

            root.Left = Swap(root.Left, height, currentHeight + 1);
            root.Right = Swap(root.Right, height, currentHeight + 1);
            return root;
        }
    }
}
