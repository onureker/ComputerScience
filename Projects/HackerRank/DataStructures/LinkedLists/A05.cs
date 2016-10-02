using Common;
using Common.DataStructures.LinkedLists;

namespace HackerRank.DataStructures.LinkedLists
{
    class A05: IProgram
    {
        //Delete a TreeNode
        //https://www.hackerrank.com/challenges/delete-a-node-from-a-linked-list
        public void Run(string[] args)
        {
            var head = Nodes.Build(3, 1, 4);
            var result = Delete(head, 1);
            result.Dump();
        }

        private Node<int> Delete(Node<int>  head, int position)
        {
            if (position == 0)
            {
                return head.Next;
            }

            var current = head;
            for (int i = 1; i < position; i++)
            {
                current = current.Next;
            }

            current.Next = current.Next.Next;
            return head;
        }

    }
}
