using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part3
{
    internal class FizzBuzz
    {
        internal static void FB()
        {
            string answer = string.Empty;
            for (int i=1; i<=100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine($"{i} - FizzBuzz");
                }

                else if (i % 3 == 0)
                    Console.WriteLine($"{i} - Fizz");

                else if (i % 5 == 0)
                    Console.WriteLine($"{i} - Buzz");

                else
                    Console.WriteLine($"{i}");



            }
        }
    }
}
