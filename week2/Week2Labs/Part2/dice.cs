using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{
    internal class dice
    {


        static void Main(string[] args)
        {

            Random random = new Random();
            int daysUntilExpiration = random.Next(12);
            int discountPercentage = 0;

            // Your code goes here
            if (daysUntilExpiration <= 0)
                Console.WriteLine("Your subscription has expired.");
            else if (daysUntilExpiration <= 1)
                Console.WriteLine("Your subscription expires within a day!\r\nRenew now and save 20%!");
            else if (daysUntilExpiration <= 5)
                Console.WriteLine($"Your subscription expires in {daysUntilExpiration} days.\r\nRenew now and save 10%!");
            else Console.WriteLine("Your subscription will expire soon. Renew now!");
        }
    }
}
