using System.Linq;

namespace Common.DataStructures.Graphs
{
    public static class NodeExtensions
    {
        public static Node GetAdjacent(this Node extended, int value)
        {
            var result = extended.Adjacent.First(node => node.Value == value);
            return result;
        }

    }
}
