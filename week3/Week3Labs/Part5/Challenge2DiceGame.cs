using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part5
{
    internal class Challenge2DiceGame
    {
        internal static void DiceGame()
        {
            Random random = new Random();

            Console.WriteLine("Would you like to play? (Y/N)");

            if (ShouldPlay())
            {
                PlayGame();
            }

            // playGame()
            void PlayGame()
            {
                var play = true;

                while (play)
                {
                    
                    var target = random.Next(1,6);
                    var roll = random.Next(1,7);

                    Console.WriteLine($"Roll a number greater than {target} to win!");
                    Console.WriteLine($"You rolled a {roll}");
                    Console.WriteLine(WinOrLose(target, roll));
                    Console.WriteLine("\nPlay again? (Y/N)");

                    play = ShouldPlay();
                }
            }

            // ShouldPlay()
            bool ShouldPlay()
            {
                String? entry = Console.ReadLine();
                if (entry == "Y" || entry == "y") return true;
                return false;
            }

            // WinOrLose()
            string WinOrLose(int target, int roll)
            {
                if (roll > target)
                    return "You win";
                else return "You lose";
            }
        }
    }
}
