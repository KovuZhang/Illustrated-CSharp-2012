#define DoTrace

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _6_2_ConditionalAttribute
{
    class Program
    {
        [Conditional("DoTrace")]
        static void TraceMessage(string str)
        {
            Console.WriteLine(str);
        }

        [Conditional("OtherTrace")]
        static void OtherTraceMessage(string str)
        {
            Console.WriteLine(str);
        }

        public static void Execute()
        {
            TraceMessage("Trace Message");
            OtherTraceMessage("Other Trace Message");
        }

        static void Main(string[] args)
        {
            Execute();
        }
    }
}
