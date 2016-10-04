using Common;
using Common.DataStructures.Arrays;

namespace CrackingTheCodingInterview.v5.DataStructures.ArraysAndStrings
{
    //Given an image represented by an NxNmatrix, where each pixel in the image is 4 bytes,
    //write a method to rotate the image by 90 degrees.Can you do this in place?
    public class A16: IProgram
    {
        public void Run(string[] args)
        {
            int[][] image = ArrayBuilder<int>.TwoDimension()
                .AddLine(00, 01, 02, 03, 04)
                .AddLine(10, 11, 12, 13, 14)
                .AddLine(20, 21, 22, 23, 24)
                .AddLine(30, 31, 32, 33, 34)
                .AddLine(40, 41, 42, 43, 44)
                .Build();
                   
            int[][] rotatedImage = Rotate(image);
            rotatedImage.Dump();
        }

        private int[][] Rotate(int[][] image)
        {
            int layerCount = image.Length / 2;
            for (int layer = 0; layer < layerCount; layer++)
            {
                int start = layer;
                int end = image.Length - layer - 1;

                for (int index = 0; index < end - start; index++)
                {
                    int top = image[start][start + index];
                    int right = image[start + index][end];
                    int bottom = image[end][end - index];
                    int left = image[end - index][start];

                    image[start][start + index] = left;
                    image[end - index][start] = bottom;
                    image[end][end - index] = right;
                    image[start + index][end] = top;
                }
            }

            return image;
        }
    }
}
