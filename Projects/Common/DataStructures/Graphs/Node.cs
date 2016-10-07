using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DataStructures.Graphs
{
    public class Node: IDataStructure
    {
        public Node()
        {
            Adjacent = new List<Node>();
        }

        public Node(int value)
            : this()
        {
            this.Value = value;
        }

        public IList<Node> Adjacent { get; set; }
        public int Value { get; set; }
    }
}
