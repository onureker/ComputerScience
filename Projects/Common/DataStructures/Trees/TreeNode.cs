namespace Common.DataStructures.Trees
{
    public class TreeNode
    {
        public int Data { get; }
        public TreeNode Left { get; set;  }
        public TreeNode Right { get; set; }

        public TreeNode(int data)
        {
            this.Data = data;
        }

    }
}
