using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _8_LoopParallel
{
    delegate bool MyDel(string s);

    class Simple
    {
        Stopwatch sw = new Stopwatch();

        public void DoRun()
        {
            Console.WriteLine("Start Calling:");
            //Task t = ShowDelayAsync();
            ShowDelay();
            Console.WriteLine("End Calling:");
        }

        //private async Task ShowDelayAsync()
        //{
        //    sw.Start();
        //    Console.WriteLine("\tCalling\t:\t{0, 4:N0} ms", sw.ElapsedMilliseconds);
        //    //await Task.Run(() => ExecuteBlock());
        //    for (int i = 0; i < 100; i++)
        //    {
        //        await Task.Run(() => ExecuteBlockSingle(i));
        //    }
        //    Console.WriteLine("\tCalling\t:\t{0, 4:N0} ms", sw.ElapsedMilliseconds);
        //}

        private void ShowDelay()
        {
            sw.Start();
            Console.WriteLine("\tCalling\t:\t{0, 4:N0} ms", sw.Elapsed.TotalMilliseconds);
            //ExecuteBlock();
            ExecuteInvoke();
            Console.WriteLine("\tCalling\t:\t{0, 4:N0} ms", sw.Elapsed.TotalMilliseconds);
        }

        private void ExecuteBlock()
        {
            //Parallel.For(0, 100, i =>
            //{
            //    for (long j = 0; j < 10000000; j++)
            //    {

            //    }

            //});

        }

        private bool ExecuteBlockSingle(string s)
        {
            for (long i = 0; i < 10000000; i++)
            {

            }

            return Convert.ToInt32(s) % 10 == 0;
        }

        private void ExecuteInvoke()
        {
            MyDel del = new MyDel(ExecuteBlockSingle);
            IAsyncResult[] iarArray = new IAsyncResult[100];

            for (int i = 0; i < 100; i++)
            {
                iarArray[i] = del.BeginInvoke(Convert.ToString(i), null, null);
            }

            Console.WriteLine("Doing Stuff");

            bool[] re = new bool[100];
            for (int i = 0; i < 100; i++)
            {
                re[i] = del.EndInvoke(iarArray[i]);
            }

            for (int i = 0; i < 100; i++)
            {
                if (i % 10 == 0)
                {
                    Console.WriteLine();
                }
                Console.Write("{0}\t", re[i]);
            }

            Console.WriteLine("Done");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Simple sp = new Simple();
            sp.DoRun();
            Console.Read();
        }
    }
}
