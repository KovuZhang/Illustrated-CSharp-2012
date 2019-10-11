using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_ArrayStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,,] arr3 = new int[3, 6, 2];
            int[] arr4 = new int[] { 10, 2, 4, 5 };
            var arr5 = new[] { 1, 2, 3, 4 };
            int[][] jagarr = new int[3][];

            Console.WriteLine(arr3.Length);
            Console.WriteLine(arr4);
            Console.WriteLine(arr5);
        }
    }
}
