using Common;
using Common.DataStructures.LinkedLists;

namespace CrackingTheCodingInterview.v5.DataStructures.LinkedLists
{
    public class A23: IProgram
    {
        //Implement an algorithm to delete a node in the middle of a singly linked list, given only access to that node
        public void Run(string[] args)
        {
            Node<string> input = Nodes.Build("a", "b", "c", "d", "e");
            Node<string> nodeToBeDeleted = input.Lookup("c");

            DeleteNode(nodeToBeDeleted);
            input.Dump();
        }

        private void DeleteNode(Node<string> node)
        {
            if (node?.Next == null)
                return;

            var next = node.Next;
            node.Data = next.Data;
            node.Next = next.Next;
        }
    }
}
