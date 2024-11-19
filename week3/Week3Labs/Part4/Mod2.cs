using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part4
{
    internal class Mod2
    {
        internal static void ExerciseDataConversion()
        {
            int first = 2;
            string second = "33";
            /*int result = first + second;*/ //-- compiler can't implicitly convert it for me, because it
                                             //doesn't know what system I am in.
            var result1 = first + second; //using var is okey 

            string result2 = first.ToString() + second;


            int myInt = 3;
            Console.WriteLine($"int: {myInt}");

            decimal myDecimal = myInt; //put int to decimal, okey, because int is smaller than decimal
            Console.WriteLine($"decimal: {myDecimal}");

            // | explicit conversion
            //when doing conversion, by default I agree that data will be truncated.
            decimal myDecimal1 = 3.14m;
            Console.WriteLine($"decimal: {myDecimal1}");
            int myInt1 = (int)myDecimal;
            Console.WriteLine($"int: {myInt1}");

            int first2 = 500;
            int second2 = 700;
            string message = first2.ToString("X") + second2.ToString("x");
            Console.WriteLine(message);

            string first3 = "5";
            string second3 = "7";
            int sum = int.Parse(first3) + int.Parse(second3);
            Console.WriteLine(sum);

            string value1 = "5";
            string value2 = "7";
            int result = Convert.ToInt32(value1) * Convert.ToInt32(value2); //convert a string to an 32bit signed int
            Console.WriteLine(result);

            string binString = "1100110";
            int result3 = Convert.ToInt32(binString, 10);
            Console.WriteLine(result3);

            //print 555 in binary string and hex-decimal
            int num = 555;
            string result4 = Convert.ToString(num, 2);
            Console.WriteLine(result4);
            string result5 = Convert.ToString(num, 16);
            Console.WriteLine(result5);

            //casting vs converting
            int value3 = (int)1.5m; // casting truncates
            Console.WriteLine(value3);
            int value4 = Convert.ToInt32(1.5m); // converting rounds up
            Console.WriteLine(value4);

        }


        internal static void TryParseSample()
        {
            //TryParse return bool type
            if (int.TryParse("5abce", out int result))
            {
                Console.WriteLine($"The string is converted to {result}");
            }
            else
            {
                Console.WriteLine("The string can't be converted to int");
            }

            //declare the out variable first
            int resultParsed2 = 0;
            if (int.TryParse("5dsdadsa", out resultParsed2))
            {
                Console.WriteLine($"The string is converted to {resultParsed2}");
            }
            else
            {
                Console.WriteLine("The string can't be converted to int");
            }

        }
    }
}
