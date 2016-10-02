using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace HackerRank
{
    class Program
    {
        static void Main(string[] args)
        {
            //var temp = nameof(DataStructures.Arrays);
            //IProgram rooter = new HackerRank.DataStructures.Arrays.Rooter();
            //IProgram rooter = new HackerRank.DataStructures.Stacks.Rooter();
            //IProgram rooter = new HackerRank.DataStructures.Queues.Rooter();
            //IProgram rooter = new HackerRank.DataStructures.LinkedLists.Rooter();

            IProgram rooter = new DataStructures.Trees.Rooter();
            rooter.Run(args);
        }
    }
}
