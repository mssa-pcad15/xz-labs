using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fundamentals1.LearnTypes1;

namespace FundamentalsTest1
{
    [TestClass]
    public class WarGameTest
    {
        [TestMethod]
        public void GamePlayThrough()
        {
            //Arrange
            Dealer dealer = new Dealer("Mad Dealer");
            Player player = new Player("Cool Player");
            player.ShouldSurrender = true;

            /* Issues with the following two lines:
             *      /***
             *      WarGame aGame = new WarGame();
             *      dealer.JoinGame(aGame);
             *      ***/
            /* WarGame can't start until a dealer join the game, but we don't know which one happens first
             */
            // | the following code change by passing in "Dealer dealer", which assign a dealer as soon as 
            //   the war game starts
            WarGame aGame = new WarGame(dealer); //equivalent code to /*** WarGame aGame = new() ***/ Introduced in C# 9.0
            //dealer.JoinGame(aGame);
            player.JoinGame(aGame);
            player.PlaceBet(10);

            //Assert
            Assert.IsTrue(aGame.Winner != null);
            Assert.IsTrue(dealer.Balance + player.Balance == 0); //by the end of the game, both should surrender their money
        }

        [TestMethod]
        public void GamePlayThrough10TimesAlwaysSurrender()
        {
            // | Person is a base class, it can't be instantiated. But anything that associated with 
            // base class will accept instances of derived class, such as Dealer and Player 
            List<Person> winners = new List<Person>(); 
            for (int i = 0; i < 10; i++) {
                Dealer dealer = new Dealer("Mad Dealer");
                Player player = new Player("Cool Player");
                player.ShouldSurrender = true;
                WarGame aGame = new WarGame(dealer); //equivalent code to /*** WarGame aGame = new() ***/ Introduced in C# 9.0
                                                     //dealer.JoinGame(aGame);
                player.JoinGame(aGame);
                player.PlaceBet(10);
                Assert.IsTrue(dealer.Balance + player.Balance == 0);
                winners.Add(aGame.Winner); // winners list is a base class list, it accept both derived
                                           // classes either Dealer or Player, we don't know who is the 
                                           // winner yet.
            }
            Assert.IsTrue(winners.Count == 10);
            // | p points to each person, where it is pointing to is an instance. Using p => p is Dealer is 
            // to test if this underlying instance is an instance of Dealer or an instance of Player
            int dealerWinCount = winners.Where(p => p is Dealer).Count();
            int playerWinCount = winners.Where(p => p is Player).Count();

            Debug.WriteLine($"{dealerWinCount} times dealer win");
            Debug.WriteLine($"{playerWinCount} times player win");



        }
    }
}
