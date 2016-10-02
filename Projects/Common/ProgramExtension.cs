using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Common
{
    public static class ProgramExtension
    {
        public static TextReader ReadFile(this IProgram extended, string fileName)
        {
            var type = extended.GetType();
            var stream = type.Assembly.GetManifestResourceStream(type, fileName);
            TextReader textReader = new StreamReader(stream);
            return textReader;
        }

        public static TextReader ReadInput(this IProgram extended)
        {
            var typeName = extended.GetType().Name;
            var fileName = $"{typeName}.input.txt";
            TextReader textReader = ReadFile(extended, fileName);
            return textReader;
        }

        public static void Swap<T>(this IProgram extended, ref T value1, ref T value2)
        {
            T temp = value1;
            value1 = value2;
            value2 = temp;
        }

        public static int Min(this IProgram extended, int value1, int value2)
        {
            return value1 < value2 ? value1 : value2;
        }

        public static int Max(this IProgram extended, int value1, int value2)
        {
            return value1 > value2 ? value1 : value2;
        }

        public static void Execute<TProgram>(this IProgram extended)
            where TProgram : IProgram, new()
        {
            TProgram program = new TProgram();
            program.Run(null);
        }

        public static void ExecuteLast(this IProgram extended)
        {
            string @namespace = extended.GetType().Namespace;
            var lastAnswer = Assembly.GetCallingAssembly().GetTypes()
                .Where(type => type.Namespace == @namespace)
                .Where(type => typeof(IProgram).IsAssignableFrom(type))
                .Where(type => type != extended.GetType())
                .OrderByDescending(type => type.Name)
                .First();

            IProgram program = (IProgram) Activator.CreateInstance(lastAnswer);
            program.Run(null);
        }
    }
}
