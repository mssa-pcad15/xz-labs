using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part3
{
    internal class Mod1
    {
        
        internal static void Challenge()
        {
            Random coin = new Random();
            int flip = coin.Next(0, 2);
            Console.WriteLine((flip == 0) ? "heads" : "tails");


        }

        internal static void Challenge2()
        {
            string permission = "Admin|Manager";
            int level = 55;

            if (permission.Contains("Admin") && level > 55) Console.WriteLine("Welcome, Super Admin user.");

            if (permission.Contains("Admin") && level <= 55) Console.WriteLine("Welcome, Admin user.");

            if (permission.Contains("Manager") && level >= 20) Console.WriteLine("Contact an Admin for access.");

            if (permission.Contains("Manager") && level < 20) Console.WriteLine("You do not have sufficient privileges.");

            if (!permission.Contains("Manager") && !permission.Contains("Admin")) Console.WriteLine("You do not have sufficient privileges.");





        }
    }
}
