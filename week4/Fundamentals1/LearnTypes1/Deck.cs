﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals1.LearnTypes1
{
    public class Deck : IEquatable<Deck>
    {
        /*********** Begin: for test -- NewDeckOfCardWillHaveCardsInSuitToRankOrder() *********/
        public const int NumberOfCards = 52;
        private Card[] _cards = new Card[NumberOfCards];//create an array which is Card type and assgin the capacity as 52

        // | bool property
        // flag indicates whether Deck has been shuffled
        //"private set": The property value can only be set privately (inside the same class where the property
        //is declared).
        public bool IsInNewDeckOrder { get; private set; } //default value for bool is "false"
        /*********** End: for test -- NewDeckOfCardWillHaveCardsInSuitToRankOrder() *********/



        /*********** Begin: for test -- DealACardShouldReturnNextCardInTheDeck() *********/
        //1. Initialize a private field to serve as counter to number of cards dealt
        private int currentCard = 0;
        public int RemainingCards => NumberOfCards - currentCard; //A property with implicit "get" method.
        /*********** End: for test -- DealACardShouldReturnNextCardInTheDeck() *********/


        // | constructor
        public Deck() //in constructor, we create 52 card in Suit/Rank order and set IsInNewDeckOrder flag to true
            {
            int cardPosition = 0; //used to point at each card position.

            for (int i = 1; i <= 4; i++) { 
            
                foreach (CardRank r in Enum.GetValues<CardRank>()){ //get the int value from CardRank Enum
                    this._cards[cardPosition++] = new Card { Suit = (CardSuit)i, Rank = r };
                }
            }
            IsInNewDeckOrder = true;
        }

        // | GetCardByIndex() method
        public Card GetCardByIndex(int index) => _cards[index];


        /*********** Begin: for test -- DealACardShouldReturnNextCardInTheDeck() *********/
        //2. Write an instance method which deal with the next card
        public Card Deal() => GetCardByIndex(currentCard++);
        /*********** End: for test -- DealACardShouldReturnNextCardInTheDeck() *********/


        /*********** Begin: for test -- ADeckCanBeShuffled() *********/
        public void Shuffle()
        {
            Random random = new Random();
            for (int i=0; i<1000; i++){
                int from = random.Next(52);
                int to = random.Next(52);
                (_cards[from], _cards[to]) = (_cards[to], _cards[from]);
            }
            IsInNewDeckOrder = false;
        }

        public override string ToString()
        {
            return string.Join(',', _cards);
        }

        public bool Equals(Deck? other)
        {
            if (other == null) return false;
            for (int i = 0; i < NumberOfCards; i++)
            {
                Card a = this.Deal();
                Card b = other.Deal();
                if (a != b) return false; //in Card struct, "record" allows member comparison
            }
            return true;
        }
        /*********** End: for test -- ADeckCanBeShuffled() *********/



    }
}
