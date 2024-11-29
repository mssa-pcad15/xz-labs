using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals1.LearnTypes1
{
    public struct Card
    {
       public CardSuit Suit { get; set; } //"CardSuit": enum, "Suit": an enum object
       public CardRank Rank { get; set; }

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

    
}
