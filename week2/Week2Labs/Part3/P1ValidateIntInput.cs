using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part3
{
    /*
     * If the integer value isn't between 5 and 10, your code must use a Console.WriteLine() statement to prompt the user for 
     * an integer value between 5 and 10. Your solution must ensure that the integer value is between 5 and 10 before exiting
     * the iteration.
    */
    internal class P1ValidateIntInput
    {
        internal static void EnterValidInput()
        {
            string? readResult; // "?" refers to nullable, allows this "readResult" string to be null value
            bool isValid = true;
            int result = 0 ;
            do
            {
              Console.WriteLine("Enter an integer value between 5 and 10: ");

              readResult = Console.ReadLine();
              isValid = int.TryParse(readResult, out result);

                if (isValid == false)
                {
                    Console.WriteLine("Sorry, you entered an invalid number, please try again");
                    continue;
                }
                    



                else if (isValid == true) //if isValid true, means "readResult" can be successfully converted to int
                {
                    if (result < 5 || result > 10)
                    {
                        Console.WriteLine($"You entered {result}. Please enter a number between 5 and 10.");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"Your input value {result} has been accepted.");
                        break;
                    }
                }

            } while (isValid == false || result < 5 || result > 10);
        }
    }
}
