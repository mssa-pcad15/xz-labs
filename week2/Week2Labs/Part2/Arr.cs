using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{
    internal class Arr
    {
        static void Main(string[] args)
        {
            /*
            int[] inventory = { 200, 450, 700, 175, 250 };
            int sum = 0;

            foreach (int num in inventory)
                sum += num;

            Console.WriteLine(sum);
            */

            string[] arr = { "B123", "C234", "A345", "C15", "B177", "G3003", "C235", "B179" };

            foreach(string id in arr)
            {
                if (id.StartsWith("B"))
                    Console.WriteLine(id);
            }
            }
    }
}
