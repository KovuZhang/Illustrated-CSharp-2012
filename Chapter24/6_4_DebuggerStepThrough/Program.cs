using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _6_4_DebuggerStepThrough
{
    class Program
    {
        int _x = 5;

        int X
        {
            get
            {
                return _x;
            }

            [DebuggerStepThrough]
            set
            {
                _x = _x * 2;
                _x += value;
            }
        }

        public int Y { get; set; }

        public static void Execute()
        {
            Program d = new Program();

            d.IncrementFields();
            d.X = 5;
            Console.WriteLine("X = {0}, Y = {1}", d.X, d.Y);
        }

        [DebuggerStepThrough]
        void IncrementFields()
        {
            X++; // X = (X.get + 1) -> X = (_x + 1) -> value = (_x + 1)
            Y++;
        }

        static void Main(string[] args)
        {
            Execute();
        }
    }
}
