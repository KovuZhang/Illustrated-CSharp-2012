using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_13_AnonymousMethod
{
    //delegate void Handler();

    class Incrementer
    {
        public event EventHandler CountedADozen;

        public void DoCount()
        {
            for (int i = 1; i < 100; i++)
            {
                if (i % 12 == 0 && CountedADozen != null)
                    CountedADozen(this, null);
            }
        }
    }

    class Dozens
    {
        public int DozensCount { get; private set; }

        public Dozens(Incrementer incrementer)
        {
            DozensCount = 0;
            incrementer.CountedADozen += IncrementDozensCount;
        }

        void IncrementDozensCount(object sender, EventArgs e)
        {
            DozensCount++;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Incrementer incrementer = new Incrementer();
            Dozens dozensCounter = new Dozens(incrementer);

            incrementer.DoCount();
            Console.WriteLine(dozensCounter.DozensCount);
        }
    }
}
