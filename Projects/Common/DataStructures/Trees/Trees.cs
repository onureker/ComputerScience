using System;

namespace Common.DataStructures.Trees
{
    public class Trees
    {
        public static TreeNode Parse(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }

            int start = input.IndexOf("(", StringComparison.Ordinal);
            int end = input.Length - 1;
            if (start == -1)
            {
                TreeNode result = new TreeNode(int.Parse(input));
                return result;
            }

            string value = input.Substring(0, start);
            TreeNode treeNode = new TreeNode(int.Parse(value));
            string other = input.Substring(2, end-2);
            int commaPosition = FindCommaPosition(other);

            string left = commaPosition == -1 ? other : other.Substring(0, commaPosition);
            TreeNode leftTreeNode = Parse(left);

            string right = commaPosition == -1 ? null : other.Substring(commaPosition + 1, other.Length - commaPosition - 1);
            TreeNode rightTreeNode = Parse(right);

            treeNode.Left = leftTreeNode;
            treeNode.Right = rightTreeNode;

            return treeNode;
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
