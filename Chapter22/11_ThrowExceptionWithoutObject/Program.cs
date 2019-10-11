using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_ThrowExceptionWithoutObject
{
    class TEWOClass
    {
        public static void PrintArg(string arg)
        {
            try
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
                    Console.WriteLine("Inner Catch:  {0}", e.Message);
                    throw;
                }
            }
            catch (System.Exception)
            {
                Console.WriteLine("Outer Catch:  Handling an Exception.");
            }
        }
    }

    class Program
    {
        public static void Execute()
        {
            TEWOClass.PrintArg(null);
        }

        static void Main(string[] args)
        {
            Execute();
        }
    }
}
