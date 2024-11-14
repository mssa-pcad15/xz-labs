using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Part3
{
    internal class Mod2
    {
        internal static void Challenge()
        {
            int[] numbers = { 4, 8, 15, 16, 23, 42 };
            bool found = false;
            int total = 0;

            foreach (int number in numbers)
            {
                total += number;
                if (number == 42)
                {
                    found = true;

                }
            }

            if (found)
            {
                Console.WriteLine("Set contains 42");

            }

            Console.WriteLine($"Total: {total}");

            // Code sample 1
            //bool flag = true;
            //int value;

            //if (flag)
            //{
            //    value = 10;
            //    Console.WriteLine($"Inside the code block: {value}");
            //}

            //Console.WriteLine($"Outside the code block: {value}");
        }
    }
}
