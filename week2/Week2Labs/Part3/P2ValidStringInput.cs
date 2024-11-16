using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part3
{
    internal class P2ValidStringInput
    {
        /*
         * Your solution must ensure that the value entered matches one of the three role options(Administrator, Manager, or User).
         * Your solution should use the Trim() method on the input value to ignore leading and trailing space characters.
         * Your solution should use the ToLower() method on the input value to ignore case.
         * If the value entered isn't a match for one of the role options, your code must use a Console.WriteLine() 
           statement to prompt the user for a valid entry.
         */

        internal static void EnterStringInput()
        {
            string? readResult;


            do
            {
                Console.WriteLine("Enter your role name (Administrator, Manager, or User)");
                readResult = Console.ReadLine().Trim().ToLower();
                if (readResult != "administrator" && readResult != "manager" && readResult != "user")
                {
                    Console.WriteLine($"The role name that you entered, \"{readResult}\" is not valid. Enter your role name (Administrator, Manager, or User)");
                    continue;
                }
                else
                {
                    Console.WriteLine($"Your input value {readResult} has been accepted.");
                    break;
                }
            }
            while (true);
        }
    }
}
