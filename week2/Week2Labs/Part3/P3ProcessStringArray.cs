using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part3
{
    internal class P3ProcessStringArray
    {
        /*
         * Variable periodLocation to hold the location of the period character within a string.
         * 
         
         */
        internal static void ProcessStringArrayContent()
        {
            int periodLocation = 0;
            string myString = "";
            string[] myStrings = new string[2] { "I like pizza. I like roast chicken. I like salad", "I like all three of the menu choices" };
            
            for (int i = 0; i < myStrings.Length; i++) {
                myString = myStrings[i];
                string mySentence = string.Empty; 
                periodLocation = myString.IndexOf("."); //if not found, then return -1

                while (periodLocation != -1) //period is found
                {
                    mySentence = myString.Remove(periodLocation); //remove the entire substring start from period location

                    myString = myString.Substring(periodLocation + 1); //redefine myString, make it be the remainder of the string after the period

                    myString = myString.TrimStart();

                    periodLocation = myString.IndexOf("."); //find the next periodLocation

                    Console.WriteLine(mySentence);
                }
                mySentence = myString.Trim();
                Console.WriteLine(mySentence);


            }
        }
    }
}
