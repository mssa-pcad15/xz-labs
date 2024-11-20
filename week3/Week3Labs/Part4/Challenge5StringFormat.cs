using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part4
{
    internal class Challenge5StringFormat
    {
        /*
        Output: 

        Dear Ms. Barros,
        As a customer of our Magic Yield offering we are excited to tell you about a new financial product that would dramatically increase your return.

        Currently, you own 2,975,000.00 shares at a return of 12.75%.

        Our new product, Glorious Future offers a return of 13.13%.  Given your current volume, your potential profit would be $63,000,000.00.

        Here's a quick comparison:

        Magic Yield         12.75%   $55,000,000.00      
        Glorious Future     13.13%   $63,000,000.00
         */
        internal static void StringFormat()
        {
            string customerName = "Ms. Barros";

            string currentProduct = "Magic Yield";
            int currentShares = 2975000;
            decimal currentReturn = 0.1275m;
            decimal currentProfit = 55000000.0m;

            string newProduct = "Glorious Future";
            decimal newReturn = 0.13125m;
            decimal newProfit = 63000000.0m;

            // Your logic here
            string message = $"""
                Dear {customerName},
                As a customer of our {currentProduct} offering we are excited to tell you about a new financial product that would dramatically increase your return.

                Currently, you own {currentShares:N2} shares at a return of {currentReturn:P2}.

                Our new product, {newProduct} offers a return of {newReturn:P2}.  Given your current volume, your potential profit would be {newProfit:C2}.
                
                Here's a quick comparison:

                {currentProduct, -20} {currentReturn, -10:P2} {currentProfit, -15:C2}
                {newProduct,-20} {newReturn,-10:P2} {newProfit,-15:C2}
                
                """;
                
            // Your logic here
            


            Console.WriteLine(message);
        }
    }
}
