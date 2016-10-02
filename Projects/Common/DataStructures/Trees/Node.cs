namespace Common.DataStructures.Trees
{
    public class Node
    {
        //For java compability (HackerRank :()
        public readonly int data;
        public Node left;
        public Node right;

        public int Data => data;

        public Node Left
        {
            get { return left; }
            set { left = value; }
        }

        public Node Right
        {
            get { return right; }
            set { right = value; }
        }

        public Node(int data)
        {
            this.data = data;
        }

    }
}
