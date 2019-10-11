using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_1_ObsoleteAttribute
{
    class Program
    {
        [Obsolete("Use method SuperPrintOut")]
        static void PrintOut(string str)
        {
            Console.WriteLine(str);
        }

        public static void Execute()
        {
            PrintOut("Start of Main");
        }

        static void Main(string[] args)
        {
            Execute();
        }
    }
}
