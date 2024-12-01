using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals1.LearnTypes1
{
    public record struct Card : IComparable<Card>
    {
       public CardSuit Suit { get; set; } //"CardSuit": enum, "Suit": an enum object
       public CardRank Rank { get; set; }


        //Same code as -- public int CompareTo(Card other) => this.Rank.CompareTo(other.Rank);
        public int CompareTo(Card other)
        {
            return this.Rank.CompareTo(other.Rank);
        }

        /*
         * Create a ToString() method to print suits
         */
        //"base" refers to the base class of the Card struct, which is System.ValueType, and
        //indirectly System.Object.
        public override string ToString()
        {
            string result = string.Empty;
            switch (Suit) //tip to generate switch case fast: switch-->tab-->change name of variable I want
                          //to use switch-->enter-->down arrow
            {
                case CardSuit.Spade:
                    result = "♠";
                    break;
                case CardSuit.Heart:
                    result = "♥";
                    break;
                case CardSuit.Club:
                    result = "♣";
                    break;
                case CardSuit.Diamond:
                    result = "♦";
                    break;
                default:
                    break;
            }

            result += (int)Rank;
            return result;
        }
    }

    /* 
     * create an enum to represent Rank
     */
    public enum CardRank
    {
        Ace=1,
        Two=2, 
        Three=3,
        Four=4,
        Five=5,
        Six=6,
        Seven=7,
        Eight=8,
        Nine=9,
        Ten=10,
        Jack=11,
        Queen=12,
        King=13
    }

    public enum CardSuit
    {
        Spade=1,
        Heart=2,
        Club=3,
        Diamond=4
    }


    public class RankOnlyComparer : IComparer<Card>
    {
        public int Compare (Card x, Card y)
        {
            return x.Rank.CompareTo(y.Rank); //CompareTo is a built-in enum method
        }
    }

    public class RankSuitComparer : IComparer<Card> 
    {
        public int Compare(Card x, Card y) {
            int valX = (int)x.Suit * 100 + (int)x.Rank;
            int valY = (int)y.Suit * 100 + (int)x.Rank;

            return valX.CompareTo(valY);
        }
    }




    
}
