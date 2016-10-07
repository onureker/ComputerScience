using System.Diagnostics;

namespace Common.DataStructures.LinkedLists
{
    [DebuggerDisplay("{Data}")]
    public class Node<T>: IDataStructure
    {
        public Node<T> Previous { get; set; }
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
