using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part5
{
    internal class Challenge1DisplayEmailAddress
    {
        internal static void DisplayEmailAddress()
        {
            string[,] corporate =
{
            {"Robert", "Bavin"}, {"Simon", "Bright"},
            {"Kim", "Sinclair"}, {"Aashrita", "Kamath"},
            {"Sarah", "Delucchi"}, {"Sinan", "Ali"}
};

            string[,] external =
            {
            {"Vinnie", "Ashton"}, {"Cody", "Dysart"},
            {"Shay", "Lawrence"}, {"Daren", "Valdes"}
};

            string externalDomain = "@hayworth.com";

            string firstTwoLetter = string.Empty;
            string fullLastName = string.Empty;
            string emailAddress = string.Empty;

            for (int i = 0; i < corporate.GetLength(0); i++) //GetLength(0): get the number of rows
            {
                // display internal email addresses
                getEmail(firstNameLetter: corporate[i, 0], fullLastName: corporate[i, 1]);
            }

            for (int i = 0; i < external.GetLength(0); i++)
            {
                // display external email addresses
                getEmail(firstNameLetter: external[i, 0], fullLastName: external[i, 1], emailAddress: externalDomain);
            }

            void getEmail(string firstNameLetter, string fullLastName, string emailAddress = "contoso.com")
            {
                string preEmail = firstNameLetter.Substring(0,2).ToLower() + fullLastName.ToLower();
                Console.WriteLine($"{preEmail}@{emailAddress}");
            }
        }
    }
}
