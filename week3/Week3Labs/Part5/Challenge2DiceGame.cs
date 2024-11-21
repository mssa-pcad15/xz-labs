//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Part5
//{
//    internal class Challenge2DiceGame
//    {
//        internal void DiceGame()
//        {
//            Random random = new Random();

//            Console.WriteLine("Would you like to play? (Y/N)");
//            String? entry = Console.ReadLine();
//            if (entry == "N") ;
//            if (entry == "Y") PlayGame();

//            if (ShouldPlay())
//            {
//                PlayGame();
//            }

//            void PlayGame()
//            {
//                var play = true;

//                while (play)
//                {
//                    var target;
//                    var roll;

//                    Console.WriteLine($"Roll a number greater than {target} to win!");
//                    Console.WriteLine($"You rolled a {roll}");
//                    Console.WriteLine(WinOrLose());
//                    Console.WriteLine("\nPlay again? (Y/N)");

//                    play = ShouldPlay();
//                }
//            }
//        }
//    }
//}
