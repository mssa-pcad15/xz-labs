using Microsoft.Win32;
using System.Collections;
using System.Diagnostics;

namespace Part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random dice;
            dice = new Random();
            int roll = dice.Next(1,7); // a 32-bit signed integer from 1~6
            Console.WriteLine(roll);

            /*
               //Process notepad = Process.Start("notepad.exe");
               //notepad.WaitForExit();
            */

            /*
               //string myComputerName = Environment.GetEnvironmentVariable("COMPUTERNAME");
               //Console.WriteLine(myComputerName);
            */

            foreach(DictionaryEntry pair in Environment.GetEnvironmentVariables())
            {
                Console.WriteLine($"{pair.Key}-{pair.Value}");
            }

            //Registry.CurrentUser.


            DirectoryInfo windowsFolder = new DirectoryInfo(@"c:\Windows");
            DirectoryInfo programFolder = new DirectoryInfo(@"c:\Program Files");
            DirectoryInfo userFolder = new DirectoryInfo(@"c:\users");

            Console.WriteLine($"{windowsFolder.CreationTime} {windowsFolder.Name} {windowsFolder.Parent}");
            Console.WriteLine($"{programFolder.CreationTime} {programFolder.Name} {programFolder.Parent}");
            Console.WriteLine($"{userFolder.CreationTime} {userFolder.Name} {userFolder.Parent}");


        }
    }
}
