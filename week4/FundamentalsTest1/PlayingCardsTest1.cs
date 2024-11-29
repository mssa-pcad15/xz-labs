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
    }



}
