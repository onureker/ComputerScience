using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.DataStructures.Arrays;
using HackerRank.Common;

namespace HackerRank.DataStructures.Queues
{
    class A01: IProgram
    {
        public class Point
        {
            public int X { get; }
            public int Y { get; }

            public Point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public bool IsEqual (Point other)
            {
                return X == other.X && Y == other.Y;
            }

        }

        public void Run(string[] args)
        {
            var matrix = ArrayBuilder<string>.TwoDimension()
                .AddLine(".", ".", "X", ".", ".")
                .AddLine(".", ".", ".", ".", ".")
                .AddLine(".", ".", ".", ".", ".")
                .AddLine(".", "X", ".", ".", ".")
                .AddLine(".", ".", ".", ".", "X")
                .Build();

            Point source = new Point(1, 4);
            Point target = new Point(4, 0);
            int count = matrix.Length;

            /*
            */

            /*
            var textReader = Console.In;
            var count = textReader.ReadLine().ParseToIntArray()[0];
            var matrix = InputParser.MultiLine(textReader, count).Select(Line.ToCharacters).ToArray();
            var points = textReader.ReadLine().ParseToIntArray();

            Point source = new Point(points[1], points[0]);
            Point target = new Point(points[3], points[2]);
            */

            int result = FindStep(source, target, matrix, count);
            Console.WriteLine(result);
        }

        private int FindStep(Point source, Point target, string[][] matrix, int length)
        {
            if (source.IsEqual(target))
            {
                return 0;
            }


            Queue<Point> queue = new Queue<Point>();
            queue.Enqueue(source);

            int[,] steps = new int[length, length];
            steps[source.Y, source.X] = -1;

            while (queue.Count != 0)
            {
                var current = queue.Dequeue();
                if (current.IsEqual(target))
                {
                    var result = steps[current.Y, current.X];
                    return result;
                }

                var step = steps[current.Y, current.X];
                int value = step == -1 ? 1 : step + 1;

                var left = BuildRange(0, current.X - 1).Reverse().Select(x => new Point(x, current.Y));
                var right = BuildRange(current.X + 1, length - 1).Select(x => new Point(x, current.Y));
                var top = BuildRange(0, current.Y - 1).Reverse().Select(y => new Point(current.X, y));
                var bottom = BuildRange(current.Y + 1, length - 1).Select(y => new Point(current.X, y));

                var leftRemained = ProcessPoints(left, matrix, steps, value);
                var rightRemained = ProcessPoints(right, matrix, steps, value);
                var topRemained = ProcessPoints(top, matrix, steps, value);
                var bottomRemained = ProcessPoints(bottom, matrix, steps, value);

                List<Point> nextPoints = new List<Point>();
                nextPoints.AddRange(leftRemained);
                nextPoints.AddRange(rightRemained);
                nextPoints.AddRange(topRemained);
                nextPoints.AddRange(bottomRemained);

                nextPoints.ForEach(queue.Enqueue);
            }

            return -1;
        }

        private IEnumerable<int> BuildRange(int start, int end)
        {
            return Enumerable.Range(start, end - start + 1);
        }

        private IEnumerable<Point> ProcessPoints(IEnumerable<Point> points, string[][] matrix, int[,] steps, int value)
        {
            IList<Point> result = new List<Point>();
            foreach (var point in points)
            {
                if (matrix[point.Y][point.X] == "X")
                {
                    break;
                }

                if (steps[point.Y, point.X] != 0)
                {
                    continue;
                }

                steps[point.Y, point.X] = value;
                result.Add(point);
            }

            return result;
        }
    }
}
