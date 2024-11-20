using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part4
{
    internal class Challenge6ExtractAndReplace
    {
        /*
         Quantity: 5000
         Output: <h2>Widgets &reg;</h2><span>5000</span>
        */

        internal static void ExtractAndReplace()
        {
            const string input = "<div><h2>Widgets &trade;</h2><span>5000</span></div>";

            string startTag = "<span>";
            string endTag = "</span>";

            // Your work here
            int startIndex = input.IndexOf(startTag, StringComparison.OrdinalIgnoreCase) + startTag.Length;
            int endIndex = input.IndexOf(endTag, StringComparison.OrdinalIgnoreCase);

            string quantity = input.Substring(startIndex, endIndex - startIndex);

            string tradeMark = "&trade;";
            string regex = "&reg;";

            string output = input.Replace(tradeMark, regex).Replace("<div>", "").Replace("</div>", "");
            

            Console.WriteLine($"Quantity: {quantity}");
            Console.WriteLine($"Output: {output}");


        }
    }
}
