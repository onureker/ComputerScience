using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DataStructures.Trees
{
    public static class NodeExtensions
    {
        public static void Dump(this Node extended)
        {
            IDictionary<int, IList<Node>> heightedNodes = new Dictionary<int, IList<Node>>();

            var height = extended.GetHeight();
            Enumerable.Range(0, height+ 1).ToList().ForEach(i => heightedNodes[i] = new List<Node>());
            extended.SetProperty(height);

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(extended);

            while (queue.Count != 0)
            {
                var current = queue.Dequeue();
                var currentHeight = current.GetProperty<int>();
                heightedNodes[currentHeight].Add(current);

                if (current.Left != null)
                {
                    current.Left.SetProperty(currentHeight - 1);
                    queue.Enqueue(current.Left);
                }

                if (current.Right != null)
                {
                    current.Right.SetProperty(currentHeight - 1);
                    queue.Enqueue(current.Right);
                }
            }

            foreach (var pair in heightedNodes.OrderByDescending(pair => pair.Key))
            {
                var currentHeight = pair.Key;
                var spaceCount = (int)Math.Pow(2, currentHeight);
                string space = new string(' ', spaceCount);
                var values = pair.Value.Select(node => node.data.ToString());
                var text = space + string.Join(space, values);
                Console.WriteLine(text);
            }
        }

        public static int GetHeight(this Node extended)
        {
            if (extended == null)
            {
                return -1;
            }

            var leftHeight = extended.Left.GetHeight();
            var rightHeight = extended.Right.GetHeight();
            var result = Math.Max(leftHeight, rightHeight) + 1;
            return result;
        }
    }
}
