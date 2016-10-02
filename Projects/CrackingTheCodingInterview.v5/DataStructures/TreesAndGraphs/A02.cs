using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.DataStructures.Graphs;

namespace CrackingTheCodingInterview.v5.DataStructures.TreesAndGraphs
{
    public class A02: IProgram
    {
        public void Run(string[] args)
        {
            Node root = new Node(1);
            root.Adjacent.Add(new Node(2));
            root.Adjacent.Add(new Node(3));
            root.GetAdjacent(2).Adjacent.Add(new Node(4));

            bool connected1 = IsConnected(root, root.GetAdjacent(2).GetAdjacent(4));
            Console.WriteLine(connected1);

            bool connected2 = IsConnected(root.GetAdjacent(3), root.GetAdjacent(2).GetAdjacent(4));
            Console.WriteLine(connected2);
        }

        private bool IsConnected(Node from, Node to)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(from);

            while (queue.Count != 0)
            {
                var current = queue.Dequeue();
                if (current.IsProcessed())
                {
                    continue;
                }

                current.SetProcessed();
                if (current == to)
                {
                    return true;
                }

                current.Adjacent.ToList().ForEach(queue.Enqueue);
            }

            return false;
        }
    }
}
