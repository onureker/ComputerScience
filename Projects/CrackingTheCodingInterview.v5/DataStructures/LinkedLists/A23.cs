using Common;
using Common.DataStructures.LinkedLists;

namespace CrackingTheCodingInterview.v5.DataStructures.LinkedLists
{
    //Implement an algorithm to delete a node in the middle of a singly linked list, given only access to that node.
    //EXAMPLE
    //Input: the node c from the linked list a->b->c->d->e
    //Result: nothing is returned, but the new linked list looks like a- >b- >d->e
    public class A23: IProgram
    {
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
