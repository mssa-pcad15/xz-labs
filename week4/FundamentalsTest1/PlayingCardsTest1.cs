﻿using Fundamentals1.LearnTypes1;
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
        //here the order refers to a deck of card starts from spade and ace, ends with Diamond and King
        public void NewDeckOfCardWillHaveCardsInSuitToRankOrder() 
        { 
            //Idea:
            // 1. declare private Card[] that has capacity to hold NumberOfCards
            // 2. In the constructor of Deck class, use 2 loops, where outer loop enumerates Suit
            //    and inner loop enumerates Rank to pupulate private array
            // 3. Add a public read-only bool property called IsInNewDeckOrder
            // 4. Create a method GetCard() returns a Card and accept int as index of array

            //Arrange
            Deck newDeck = new Deck();
            Card actualStart = newDeck.GetCardByIndex(0); //leaky implementation. "actual" value comes from the current program I am writing
            Card expectStart = new Card() { Suit=CardSuit.Spade, Rank=CardRank.Ace };

            Card actualEnd = newDeck.GetCardByIndex(51); //leaky implementation. 
            Card expectEnd = new Card() { Suit = CardSuit.Diamond, Rank = CardRank.King };

            //there is no Act

            //Assert
            Assert.AreEqual(actualStart, expectStart); //Two variable of struct type is compared by value, hence
                                                       //if two cards of the same suit and rank, they are equal.
            Assert.AreEqual(actualEnd, expectEnd);
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
