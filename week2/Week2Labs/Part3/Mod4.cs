using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part3
{
    internal class Mod4
    {
        internal static void forLoop()
        {

            int[] testArray = [1, 2, 3, 4, 5, 6, 7, 8, 9];
            for (int i = 0; i < testArray.Length; i++)
            {
                for (int j = 0; j<testArray.Length; j++)
                {
                    Console.Write($"{testArray[i]} * {testArray[j]} = { testArray[i] * testArray[j], 3}\t");
                }
                Console.WriteLine();
            }

            // write a for loop that roll 2 times, report immediately if hit 6x6
            for (int i = 0; i < 100; i++) {
                Random random = new Random();
                int num1 = random.Next(1, 7);
                int num2 = random.Next(1, 7);
                if (num1 + num2 == 12)
                {
                    Console.WriteLine($"Hits two 6 in {i}th roll");
                    break;
                }
            }
        }
    }
}
