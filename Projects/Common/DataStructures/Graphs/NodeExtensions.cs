using System.Collections.Generic;
using System.Linq;

namespace Common.DataStructures.Graphs
{
    public static class NodeExtensions
    {
        private static readonly IList<Node> processedList;

        static NodeExtensions()
        {
            processedList = new List<Node>();
        }

        public static Node GetAdjacent(this Node extended, int value)
        {
            var result = extended.Adjacent.First(node => node.Value == value);
            return result;
        }

        public static void SetProcessed(this Node extended)
        {
            processedList.Add(extended);
        }

        public static bool IsProcessed(this Node extended)
        {
            return processedList.Contains(extended);
        }
    }
}
