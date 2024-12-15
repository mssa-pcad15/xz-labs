using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fundamentals1.LearnTypes1
{
    public class WarGameCards
    {
        //Make 1 Batch to be In-Play
        //Make other Batch Stand-By
        Card[][] _batches = new Card[2][]; //two rows and unknown number of columns
        public Card[][] Batches { get { return _batches; } }
        public Card[] InPlayBatch { get; private set; }
        public Card[] StandbyBatch { get; private set; }

        public event EventHandler SwapBatch;
        private int currentCardPointer = 0;

        // | Constructor, to initialize 2 batches of 6 Decks shuffled
        public WarGameCards()
        {
            InitializeBatches();

            ShuffleBatch(_batches![0]); //"!": null-forgiving operator, I am telling compiler that I know this value is not null, so stop warning me about potential null references.
            ShuffleBatch(_batches![1]);
            InPlayBatch = _batches![0];
            StandbyBatch = _batches![1];
            this.SwapBatch += WarGameCards_SwapBatch; //when mouse over "SwapBatch", it shows a lighting sign, indicates it's not a method nor
                                                      //property, it's an event, the "WarGameCards_SwapBatch" is now subscribe to the SwapBatch event.
        }

        private void WarGameCards_SwapBatch(object? sender, EventArgs e)
        {
            (InPlayBatch, StandbyBatch) = (StandbyBatch, InPlayBatch);
            currentCardPointer = 0;
        }

        public Card Deal() //return type Card, method name Deal()
        {
            int cardIndex = currentCardPointer++;
            Card nextCard = InPlayBatch[cardIndex];
            if (cardIndex > 0.9 * InPlayBatch.Length)
            {
                SwapBatch?.Invoke(this, new EventArgs());//this raise event, the publisher. There might not be anyone who subscribe the event.
                                                         //this "?" is saying: is there anyone subscribe my event right now? If yes, then invoke
                                                         //the event. If not, then don't worry.
            }
            return nextCard;
        }

        private void InitializeBatches()
        {
            _batches[0] = new Card[6 * Deck.NumberOfCards]; //row 1, initialization is better to put inside the constructor
            _batches[1] = new Card[6 * Deck.NumberOfCards]; //row 1, initialization is better to put inside the constructor

            int cardPosition = 0;
            for (int i = 1; i <= 6; i++)
            { //generate 6 decks for each, total 12 decks
                Deck aDeck = new Deck();
                Deck anotherDeck = new Deck();

                aDeck.Shuffle();
                anotherDeck.Shuffle();
                for (int j = 1; j <= 52; j++)
                {
                    _batches[0][cardPosition] = aDeck.Deal();
                    _batches[1][cardPosition] = anotherDeck.Deal();
                    cardPosition++;
                }
            }
        }


        // | private ShuffleBatch() method
        private void ShuffleBatch(Card[] cards)
        {
            int numOfCards = cards.Length;
            Random random = new Random();
            for (int i = 0; i < numOfCards * 5; i++)
            {
                int from = random.Next(0, numOfCards);
                int to = random.Next(0, numOfCards);
                (cards[from], cards[to]) = (cards[to], cards[from]);
            }




            //Deal() method deals 1 card from the In-Play Batch

            //Swap Batch at 90% cards dealt

            //Reinitialize the now standby Batch
        }
    }
}