using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _9_15_2_UsingStatement
{
    class Program
    {
        static void Main(string[] args)
        {
            // using 语句
            using (TextWriter tw = File.CreateText("Lincoln.txt"))
            {
                tw.WriteLine("Four score and seven years ago...");
            }

            // using 语句
            using (TextReader tr = File.OpenText("Lincoln.txt"))
            {
                string inputString;
                while (null != (inputString = tr.ReadLine()))
                    Console.WriteLine(inputString);
            }
        }
    }
}
