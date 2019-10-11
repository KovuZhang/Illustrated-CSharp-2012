using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_2_ExceptionCallStack
{
    class EClass
    {
        public void A()
        {
            try
            {
                B();
            }
            catch (System.NullReferenceException)
            {
                Console.WriteLine("catch clause in A().");
            }
            finally
            {
                Console.WriteLine("finally clause in A().");
            }
        }

        void B()
        {
            int x = 10, y = 0;
            try
            {
                x /= y;
            }
            catch (System.IndexOutOfRangeException)
            {
                Console.WriteLine("catch clause in B().");
            }
            finally
            {
                Console.WriteLine("finally clause in B().");
            }
        }
    }

    class Program
    {
        public static void Execute()
        {
            EClass eClass = new EClass();

            try
            {
                eClass.A();
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("catch clause in Execute().");
            }
            finally
            {
                Console.WriteLine("finally clause in Execute().");
            }

            Console.WriteLine("after try statement in Main.");
            Console.WriteLine("            -- Keep running.");
        }

        static void Main(string[] args)
        {
            Execute();
        }
    }
}
