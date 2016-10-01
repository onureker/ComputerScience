using System.Collections.Generic;
using System.IO;

namespace HackerRank.Common
{
    public static class InputParser
    {
        public static IEnumerable<string> MultiLine(TextReader textReader, int count)
        {
            IList<string> result = new List<string>();
            for (int i = 0; i < count; i++)
            {
                var line = textReader.ReadLine();
                result.Add(line);
            }

            return result;
        }

    }
}
