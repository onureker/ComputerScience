using System;

namespace Common.DataStructures.Trees
{
    public class Nodes
    {
        public static Node Parse(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }

            int start = input.IndexOf("(", StringComparison.Ordinal);
            int end = input.Length - 1;
            if (start == -1)
            {
                Node result = new Node(int.Parse(input));
                return result;
            }

            string value = input.Substring(0, start);
            Node node = new Node(int.Parse(value));
            string other = input.Substring(2, end-2);
            int commaPosition = FindCommaPosition(other);

            string left = commaPosition == -1 ? other : other.Substring(0, commaPosition);
            Node leftNode = Parse(left);

            string right = commaPosition == -1 ? null : other.Substring(commaPosition + 1, other.Length - commaPosition - 1);
            Node rightNode = Parse(right);

            node.Left = leftNode;
            node.Right = rightNode;

            return node;
        }

        private static int FindCommaPosition(string other)
        {
            int count = 0;
            char[] charArray = other.ToCharArray();
            for (int i = 0; i < charArray.Length; i++)
            {
                char c = charArray[i];
                if (c == '(')
                {
                    count++;
                    continue;
                }
                if (c == ')')
                {
                    count--;
                    continue;
                }

                if (c == ',' && count == 0)
                {
                    return i;
                }
            }

            return -1;
        }

    }
}
