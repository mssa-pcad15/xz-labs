using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part5
{
    internal class Exercise4ReusableMethod
    {
        internal static void ReusableMethod()
        {
            Random random = new Random();
            int luck = random.Next(100);


            string[] text = { "You have much to", "Today is a day to", "Whatever work you do", "This is an ideal time to" };
            string[] good = { "look forward to.", "try new things!", "is likely to succeed.", "accomplish your dreams!" };
            string[] bad = { "fear.", "avoid major decisions.", "may have unexpected outcomes.", "re-evaluate your life." };
            string[] neutral = { "appreciate.", "enjoy time with friends.", "should align with your values.", "get in tune with nature." };
            Console.WriteLine("A fortune teller whispers the following words:");
            tellFortune();       

            //a local method doesn't need to pass in local parameters it can access these local parameters by default
            void tellFortune()
            {
                string[] fortune = (luck > 75 ? good : (luck < 25 ? bad : neutral));
                for (int i = 0; i < 4; i++)
                {
                    Console.Write($"{text[i]} {fortune[i]} ");
                }
            }
        }
    }
}
