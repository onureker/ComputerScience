using System.Collections.Generic;
using System.Linq;
using Common;
using Common.DataStructures.LinkedLists;
using Common.DataStructures.Trees;

namespace CrackingTheCodingInterview.v5.DataStructures.TreesAndGraphs
{
    //Given a binary tree, design an algorithm which creates a linked list of all the nodes at each depth
    //(e.g., if you have a tree with depth D, you'll have D linked lists)
    class A04: IProgram
    {
        public void Run(string[] args)
        {
            var root = TreeBuilder.Parse("5(1(3,4),2(7,8))");
            IDictionary<int, Node<int>> lists = BuildLinkLists(root);
            lists.ToList().ForEach(pair => pair.Value.Dump());
        }

        private IDictionary<int, Node<int>> BuildLinkLists(Node root)
        {
            var result = new Dictionary<int, Node<int>>();
            Traverse(root, 0, result);
            return result;
        }

        private void Traverse(Node root, int depth, Dictionary<int, Node<int>> result)
        {
            if (root == null)
            {
                return;
            }

            Node<int> linkedListNode = Nodes.Build(root.Data);
            if (!result.ContainsKey(depth))
            {
                result.Add(depth, linkedListNode);
            }
            else
            {
                var tail = result[depth];
                linkedListNode.Next = tail;
                result[depth] = linkedListNode;
            }

            Traverse(root.Left, depth+1, result);
            Traverse(root.Right, depth+1, result);
        }
    }
}
