using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace _6_3_CallerInfoAttribute
{
    class Program
    {
        public static void MyTrace(string message,
                                [CallerFilePath]   string fileName = "",
                                [CallerLineNumber] int lineNumber = 0,
                                [CallerMemberName] string callingMember = "")
        {
            Console.WriteLine("File:        {0}", fileName);
            Console.WriteLine("Line:        {0}", lineNumber);
            Console.WriteLine("Called From: {0}", callingMember);
            Console.WriteLine("Message:     {0}", message);
        }

        public static void Execute()
        {
            MyTrace("Simple Message");
        }

        static void Main(string[] args)
        {
            Execute();
        }
    }
}
