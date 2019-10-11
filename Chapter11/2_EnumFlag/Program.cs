using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_2_EnumFlag
{
    class Program
    {
        [Flags]
        enum CardDeckSettings : uint
        {
            SingleDeck = 0x01,
            LargePictures = 0x02,
            FancyNumbers = 0x04,
            Animation = 0x08
        }

        static void Main(string[] args)
        {
            CardDeckSettings ops = CardDeckSettings.SingleDeck
                                | CardDeckSettings.FancyNumbers
                                | CardDeckSettings.Animation;

            Console.WriteLine(ops.ToString());
        }
    }
}
