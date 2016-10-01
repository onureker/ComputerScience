namespace Common.DataStructures.Trees
{
    public class Node
    {
        public int Data { get; }
        public Node Left { get; set;  }
        public Node Right { get; set; }

        public Node(int data)
        {
            this.Data = data;
        }

    }
}
