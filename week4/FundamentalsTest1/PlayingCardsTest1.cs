using Fundamentals1.LearnTypes1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundamentalsTest1
{
    [TestClass]
    public class PlayingCardsTest1
    {
        [TestMethod]
        public void CardToStringPrintsUnicode()
        {
            //Arrange
            Card aceOfSpade = new Card() { Rank=CardRank.Ace, Suit=CardSuit.Spade  };
            string expect = "♠1"; //tested with ♠11, which is SpadeJack, passed the test

            //Act
            string actual = aceOfSpade.ToString();

            //Assert
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void ADeckShouldAlwaysHave52Cards()
        { //step1: add a new public class "Deck.cs" under Fundamentals1. This class must have a
          //  static int member NumberOfCards that is assigned to value of 52

            //Arrange
            int actual = Deck.NumberOfCards;
            int expect = 52;

            // there is no Act

            //Assert
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void NewDeckOfCardWillHaveCardsInSuitToRank()
        {
            //Arrange


            //Act


            //Assert
        }

        [TestMethod]
        public void ADeckCanBeShuffled()
        {
            //Arrange


            //Act


            //Assert
        }

        [TestMethod]
        public void DealACardShouldReturnNextCardInTheDeck()
        {
            //Arrange


            //Act


            //Assert
        }

        [TestMethod]
        public void PrintsCardsInDeck()
        {
            //Arrange


            //Act


            //Assert
        }
    }



}
