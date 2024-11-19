using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part4
{
    internal class Challenge1
    {
        /*
         - Rule 1: If the value is alphabetical, concatenate it to form a message.

         - Rule 2: If the value is numeric, add it to the total.
         */
        internal static void CombineStringArray()
        {
            string[] values = { "12.3", "45", "ABC", "11", "DEF" };
            double sum = 0;
            string message = String.Empty;
            foreach(string value in values)
            {
                if (double.TryParse(value, out double number))
                {
                    sum += number;
                }
                else
                {
                    message += value;
                }
            }

            Console.WriteLine($"Message: {message}");
            Console.WriteLine($"Total: {sum}");
        }
    }
}
