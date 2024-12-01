using Fundamentals1.LearnTypes1;

namespace FundamentalsTest1
{
    [TestClass]
    public class PlayingCardsTest1
    {
        [TestMethod]
        public void CardToStringPrintsUnicode()
        {
            //Arrange
            Card aceOfSpade = new Card() { Rank = CardRank.Ace, Suit = CardSuit.Spade };
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
            Card expectStart = new Card() { Suit = CardSuit.Spade, Rank = CardRank.Ace };

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
            Deck deckA = new Deck();
            Deck deckB = new Deck();

            //Act
            deckA.Shuffle();

            //Assert
            Assert.AreNotEqual(deckA, deckB); //This testing is dangerous because AreNotEqual compares values, 
                                              //while deckA and deckB are two different objects, hence even if before shuffling, the
                                              //AreNotEqual method will always evaluate to true.
            Assert.IsFalse(deckA.IsInNewDeckOrder);
        }

        [TestMethod]
        public void DealACardShouldReturnNextCardInTheDeck()
        {
            //1. Initialize a private field to serve as counter to number of cards dealt
            //2. Write an instance method which deal with the next card
            //3. Write a method called Deal() to return the card according to the counter
            //4. Write a get property to indicate how many cards left in the deck

            //Arrange
            Deck deckA = new Deck();

            //Act
            _ = deckA.Deal(); //"_" indicates discarding the return value
            _ = deckA.Deal();
            Card thirdCard = deckA.Deal();

            //Assert
            Card expect = new Card { Rank = CardRank.Three, Suit = CardSuit.Spade };
            Assert.AreEqual(expect, thirdCard); //test: if the card I dealt is the same as the expected card I set
            Assert.AreEqual(deckA.RemainingCards, 49); //test: took three cards, left 49 cards
        }


        [TestMethod()] //[TestMethod()] is the same as [TestMethod]
        /* | This attribute indicates that the test method is expected to throw an IndexOutOfRangeException. If
         * exception is not thrown, the test will fail.
         */
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CallDealBeyondLastCardShouldThrowIndexOutOfRangeException()
        {
            //var keyword for type inference. The compiler automatically determines the type of deckA based on the
            //right-hand side (new Deck()), so var is equivalent to writing Deck deckA = new Deck();
            var deckA = new Deck();
            for (int i = 0; i < 53; i++)
                _ = deckA.Deal();

        }


        [TestMethod]
        public void PrintsCardsInDeck()
        {
            //Arrange


            //Act


            //Assert
        }


        [TestMethod]
        public void SortCards()
        {
            //Arrange
            Card[] fiveCards = new Card[]
            {
                new Card { Rank = CardRank.Five, Suit = CardSuit.Spade },
                new Card { Rank = CardRank.Nine, Suit = CardSuit.Spade },
                new Card { Rank = CardRank.Two, Suit = CardSuit.Spade },
                new Card { Rank = CardRank.Jack, Suit = CardSuit.Spade },
                new Card { Rank = CardRank.Ace, Suit = CardSuit.Spade }
            };

            //Act
            Array.Sort(fiveCards);
            //foreach (Card c in fiveCards)
            //    Console.WriteLine(c);

            //Assert
            Assert.AreEqual(fiveCards[0], new Card { Rank = CardRank.Ace, Suit = CardSuit.Spade });
            Assert.AreEqual(fiveCards[1], new Card { Rank = CardRank.Two, Suit = CardSuit.Spade });
            Assert.AreEqual(fiveCards[2], new Card { Rank = CardRank.Five, Suit = CardSuit.Spade });
            Assert.AreEqual(fiveCards[3], new Card { Rank = CardRank.Nine, Suit = CardSuit.Spade });
            Assert.AreEqual(fiveCards[4], new Card { Rank = CardRank.Jack, Suit = CardSuit.Spade });
        }
    }
}
