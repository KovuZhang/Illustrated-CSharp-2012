using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_ThrowException
{
    class TEClass
    {
        public static void PrintArg(string arg)
        {
            try
            {
                if (arg == null)
                {
                    ArgumentNullException myEx = new ArgumentNullException("arg");
                    throw myEx;
                }
                Console.WriteLine(arg);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Message:  {0}", e.Message);
            }
        }
    }

    class Program
    {
        public static void Execute()
        {
            TEClass.PrintArg(null);
            TEClass.PrintArg("Hi there!");
        }

        static void Main(string[] args)
        {
            Execute();
        }
    }
}
