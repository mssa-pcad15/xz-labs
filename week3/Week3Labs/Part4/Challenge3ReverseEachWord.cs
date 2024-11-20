using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part4
{
    internal class Challenge3ReverseEachWord
    {
        internal static void ReverseEachWord()
        {
            string pangram = "The quick brown fox jumps over the lazy dog";
            //1. split each word by delimiter " ", and put them into a string array
            string[] splitString = pangram.Split(" ");

            //2. reverse each word
            //foreach (string word in splitString)
            /*++++++++++++ Can't directly reverse each string inside the foreach, because string
             * is immutable
             ++++++++++++*/


            for (int i = 0; i < splitString.Length; i++) 
            {
                /* splitString[i] = new String(splitString[i].ToCharArray().Reverse().ToArray()); */

                //convert each string to charArray
                char[] charArray = splitString[i].ToCharArray();
                //reverse each char in in each charArray
                Array.Reverse(charArray);
                //convert each reversed charArray to string
                splitString[i] = new String(charArray);
                
            }


            string result = String.Join(" ", splitString);
            
            Console.WriteLine(result);
        }
    }
}
