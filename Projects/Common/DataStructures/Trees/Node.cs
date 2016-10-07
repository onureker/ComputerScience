namespace Common.DataStructures.Trees
{
    public class Node: IDataStructure
    {
        //For java compability (HackerRank :()
        public Node left;
        public Node right;
        public int data;

        public int Data
        {
            get { return data; }
            set { data = value; }
        }

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

        public Node()
        {
        }

        public Node(int data)
        {
            this.data = data;
        }

    }
}
