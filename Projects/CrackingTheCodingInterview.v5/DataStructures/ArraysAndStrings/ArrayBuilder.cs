using System.Collections.Generic;
using System.Linq;

namespace CrackingTheCodingInterview.v5.DataStructures.ArraysAndStrings
{
    public class ArrayBuilder<T>
    {
        private readonly IList<T[]> lines;

        private ArrayBuilder()
        {
            this.lines = new List<T[]>();
        }

        public static T[] New(params T[] values)
        {
            return values;
        }

        public static ArrayBuilder<T> TwoDimension()
        {
            return new ArrayBuilder<T>();
        }

        public ArrayBuilder<T> AddLine(params T[] values)
        {
            lines.Add(values);
            return this;
        }

        public T[][] Build()
        {
            return lines.ToArray();
        }
    }
}
