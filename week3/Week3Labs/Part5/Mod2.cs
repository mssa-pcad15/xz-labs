using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Part5
{
    internal class Mod2
    {
        internal static void Exercise1()
        {
            int[] schedule = { 800, 1200, 1600, 2000 };

            DisplayAdjustedTimes(schedule, 6, -6);

            void DisplayAdjustedTimes(int[] times, int currentGMT, int newGMT)
            {
                int diff = 0;
                if (Math.Abs(newGMT) > 12 || Math.Abs(currentGMT) > 12)
                {
                    Console.WriteLine("Invalid GMT");
                }
                else if (newGMT <= 0 && currentGMT <= 0 || newGMT >= 0 && currentGMT >= 0)
                {
                    diff = 100 * (Math.Abs(newGMT) - Math.Abs(currentGMT));
                }
                else
                {
                    diff = 100 * (Math.Abs(newGMT) + Math.Abs(currentGMT));
                }

                for (int i = 0; i < times.Length; i++)
                {
                    int newTime = ((times[i] + diff)) % 2400;
                    Console.WriteLine($"{times[i]} -> {newTime}");
                }
            }
        }

        internal static void CubeWithArrayParam()
        {

            CalCube(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

            /*+++++++++++++ 
             * the "params" keyword recognize the list of numbers
            +++++++++++++++*/
            void CalCube(params int[] nums)
            {
                foreach (int i in nums)
                {
                    Console.WriteLine($"{i}: {Math.Pow(i, 3)}");
                }
            }

        }
    }
}
