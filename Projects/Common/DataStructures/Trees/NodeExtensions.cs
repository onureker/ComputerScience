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

                var childHeight = currentHeight - 1;
                if (childHeight == -1)
                {
                    continue;
                }

                var left = current.Left ?? Node.Null;
                left.SetProperty(childHeight);
                queue.Enqueue(left);

                var right = current.Right ?? Node.Null;
                right.SetProperty(childHeight);
                queue.Enqueue(right);

                /*
                if (current.Right != null)
                {
                    current.Right.SetProperty(currentHeight - 1);
                    queue.Enqueue(current.Right);
                }
                */
            }

            const int nodeValueLength = 1;

            foreach (var pair in heightedNodes.OrderByDescending(pair => pair.Key))
            {
                var currentHeight = pair.Key;

                var leftCount = (int)Math.Pow(2, currentHeight+1) - 2;
                string leftPad = new string(' ', leftCount);

                var spaceCount = (int)Math.Pow(2, currentHeight+2) - 2;
                string separator = new string(' ', spaceCount);
                var values = pair.Value.Select(node => node.data == 0 ? " " : node.data.ToString());
                var text = leftPad + string.Join(separator, values);
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

        public static void InOrder(this Node extended, Action<Node> action)
        {
            if (extended == null)
            {
                return;
            }

            extended.Left.InOrder(action);
            action(extended);
            extended.Right.InOrder(action);
        }
    }
}
