using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part5
{
    internal class Mod1
    {
        internal static void Exercise1()
        {
            Console.WriteLine("Calling DisplayRandomNumber");
            DisplayRandomNumber();
        }

        static void DisplayRandomNumber()
        {
            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"{random.Next(1, 100)} ");
            }

            Console.WriteLine();
        }


    }
}
