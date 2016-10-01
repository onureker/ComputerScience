using Common;
using CrackingTheCodingInterview.v5.DataStructures.LinkedLists;
using CrackingTheCodingInterview.v5.DataStructures.StacksAndQueues;

namespace CrackingTheCodingInterview.v5
{
    partial class Program
    {
        static void Main(string[] args)
        {
            //A1();
            //A2();
            Run<A3>();
        }

        private static void A2()
        {
            //Run<A21>();
            //Run<A22>();
            //Run<A23>();
            //Run<A24>();
            //Run<A25>();
            //Run<A25Followup>();
            Run<A27>();
        }

        private static void A1()
        {
            //Run<A11>();
            //Run<A12>();
            //Run<A13>();
            //Run<A14>();
            //Run<A15>();
            //Run<A16>();
            //Run<A17>();
            //Run<A18>();
        }

        public static void Run<TProgram>(string[] args = null)
            where TProgram: IProgram, new()
        {
            TProgram program = new TProgram();
            program.Run(args);
        }

    }
}
