using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part4
{
    internal class Mod5
    {
        internal static void StringMethods1()
        {
            string stringToSearch = "Mary had a little lamb";
            int result = stringToSearch.IndexOf('a');
            Console.WriteLine(result);

            int result2 = stringToSearch.IndexOf("had");
            Console.WriteLine($" \"had\" is found on the {result2} position");

            int result3 = stringToSearch.IndexOf('a', 3, 4);
            Console.WriteLine($"a is found on the {result3} position");

            int howManyA = stringToSearch.Where(c => c ==  'a').Count();
            Console.WriteLine($"there are {howManyA} a in the string");
            string stringToChop = "Mary had a little lamb, it was decilious";
            
            string sub1 = stringToChop.Substring(5,8);
            Console.WriteLine($"{sub1}");

            string sub2 = stringToChop[5..14];
            Console.WriteLine($"{sub2}");

            //remove() doesn't change the original string, it returns a new string
            string choppedString = stringToChop.Remove(5, 3); //start from index5 and revmove 3 letters
            Console.WriteLine($"choppedString: {choppedString}");
            Console.WriteLine($"stringToChop: {stringToChop}");
            Console.WriteLine(stringToChop.Replace("mary", "bob", StringComparison.OrdinalIgnoreCase));

            if(DateTime.Now.DayOfWeek == DayOfWeek.Tuesday)
            {

            }
        }
    }
}
