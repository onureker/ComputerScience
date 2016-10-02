using System.Collections.Generic;
using Common;
using Common.DataStructures.LinkedLists;

namespace CrackingTheCodingInterview.v5.DataStructures.LinkedLists
{
    public class A21: IProgram
    {
        public void Run(string[] args)
        {
            Node<int> input = Nodes.Build(3, 1, 4, 3, 7, 1, 9, 10);
            input.Dump();

            //TreeNode<int> output1 = RemoveDuplicate(input);
            //output1.Dump();

            Node<int> output2 = RemoveDuplicateFollowUp(input);
            output2.Dump();
        }

        private Node<int> RemoveDuplicateFollowUp(Node<int> head)
        {
            for (Node<int> current = head; current != null; current = current.Next)
            {
                int value = current.Data;
                Node<int> previous = current;
                for (Node<int> runner = current.Next; runner != null; previous = runner, runner = runner.Next)
                {
                    int runnerValue = runner.Data;
                    if (runnerValue != value)
                    {
                        continue;
                    }

                    previous.Next = runner.Next;
                }
            }

            return head;
        }

        private Node<int> RemoveDuplicate(Node<int> head)
        {
            // Dictionary liste ye göre hash kullandığı için daha efektif
            IDictionary<int, bool> values = new Dictionary<int, bool>();
            Node<int> previous = null;
            for (Node<int> current = head; current != null; current = current.Next)
            {
                if (!values.ContainsKey(current.Data))
                {
                    values.Add(current.Data, true);
                    previous = current;
                    continue;
                }

                previous.Next = current.Next;
            }

            return head;
        }
    }
}
