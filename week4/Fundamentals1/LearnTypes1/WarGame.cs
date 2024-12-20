using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals1.LearnTypes1
{
    public class WarGame
    {
        private Dealer _dealer;
        private Player _player;
        private int _wager;
        private WarGameCards _shoe;

        /* property: format -- data type + property name */
        public Dealer Dealer
        {
            get => _dealer; //equivalent code: get { return _dealer; }
            internal set
            {
                _dealer = value;
                this.GameOver += _dealer.OnGameOver;
                DealerReady?.Invoke(this, EventArgs.Empty);
            }
        }
        public Player Player
        {
            get => _player;
            internal set
            {
                _player = value;
                this.GameOver += _player.OnGameOver;
                PlayerReady?.Invoke(this, EventArgs.Empty);
            }
        }
        public Person Winner
        {
            get => _winner;
            set
            {
                _winner = value;
                HasWinner?.Invoke(this, value);//current instance "this" invokes "HasWinner" 
                                              //event, event data "value" is passed to subscrubers
            }
        }
        public int Wager
        {
            get { return _wager; }
            set
            {
                if (Player == null || Dealer == null) throw new Exception("Missing participant");
                _wager = value;
                PlacedWager?.Invoke(this, EventArgs.Empty);
            }
        }
        public string GameResult { get; private set; }


        /* private field */
        private Person _winner;


        /* Events */ //declare events
        public event EventHandler<EventArgs> GameInitialized;
        public event EventHandler<EventArgs> DealerReady;
        public event EventHandler<EventArgs> PlayerReady;
        public event EventHandler<EventArgs> PlacedWager;
        public event EventHandler<EventArgs> HandDealt;
        public event EventHandler<Person> HasWinner;
        public event EventHandler<EventArgs> GotoWar;
        public event EventHandler<EventArgs> GameOver;

        /* constructor */
        public WarGame(Dealer dealer)
        {
            this.Dealer = dealer;
            dealer.JoinGame(this);//Pass current instance as a reference
            this._shoe = new WarGameCards();//In future revision, the shoe would be a reference to Table's property
            Dealer.LetsGo += (o, e) => //This line subscribes an anonymous method (a lambda expression) to the LetsGo event of the
                                       //Dealer object. The += operator is used to add the event handler.
                                       //(o,e): lambda expression, o: the sender, e: the event arguments
            {
                Dealer.Hand.Add(this._shoe.Deal()); //This line adds a card dealt from the Shoe to the Dealer's hand.
                Player.Hand.Add(this._shoe.Deal()); //This line adds a card dealt from the Shoe to the Player's hand.
                HandDealt?.Invoke(this, EventArgs.Empty); //This line raises the HandDealt event, if it has any subscribers,
                                                          //passing this as the sender and EventArgs.Empty as the event arguments.
            };

            Dealer.WagerProcessed += (o, e) =>
            {
                string result = string.Empty;
                if (_winner is Dealer d)
                {
                    result = $"House win, dealer {Dealer.Name} has balance of {Dealer.Balance}, player {Player.Name} has balance of {Player.Balance}";
                }
                else
                {
                    result = $"Player win, dealer {Dealer.Name} has balance of {Dealer.Balance}, player {Player.Name} has balance of {Player.Balance}";
                }
                this.GameResult = result;
                GameOver?.Invoke(this, EventArgs.Empty);
            };

            //initialize the "GameInitialized" event, an event waiting to be invoked
            GameInitialized?.Invoke(this, EventArgs.Empty); 
        }

        internal void War()
        {
            {
                Player.DoubleDown += (o, e) =>
                {
                    Dealer.Hand.Add(_shoe.Deal());
                    Player.Hand.Add(_shoe.Deal());
                    Wager = Wager * 2;
                    HandDealt?.Invoke(this, EventArgs.Empty);
                };
                Player.Surrender += (o, e) =>
                {
                    this.Winner = Dealer;
                    //HasWinner?.Invoke(this, Dealer);
                };

                GotoWar?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    /* 
     * 1) base class "Person", which stores the common features of child class. S.A. both
       dealer and player has the same property such as name and both have a list of cards
     */
    public abstract class Person 
        {
            internal List<Card> Hand { get; set; }
            // | use protected instead of private because if use private, means only Person class can access the Balance,
            // but I want all the derived class to access this Balance too.
            public int Balance { get; protected set; } 
            public string Name { get; }

            // | constructor
            public Person(string name)
            {
                Name = name; //didn't use "this" because there is no ambuiguity
                Hand = new List<Card>();
            }

            // | use abstract, means a person should do something whenever game is over
            // but I don't know what they want to do. By defining an abstract method at
            // base class we guarantee these methods will exist in all derived class
            // Useful when we don't know what to implement yet, such as how to implement
            // an engine, but we can say all car must have an engine. But whether it is a gas, battery
            // hybrid engine, it is upto the derived class.
            public abstract void OnGameOver(object? sender, EventArgs e);

            // | use "virtual" allows me to have implementation at base class, derived class can override this implementation.
            public virtual string HowIFeel => "Good";
          };



        /* primary constructor, it is a compact form of class and constructor */
        public class Dealer(string Name) : Person(Name)
        {
            private WarGame _currentGame;

            public int Balance { get; private set; }

            public event EventHandler<EventArgs> LetsGo;
            public event EventHandler<EventArgs> WagerProcessed;

            public void JoinGame(WarGame theGame)
            {
                theGame.Dealer = this;
                this._currentGame = theGame;
                this._currentGame.PlacedWager += (o, e) => LetsGo?.Invoke(this, EventArgs.Empty);
                this._currentGame.HandDealt += (o, e) =>
                {
                    Card dealerCard = this._currentGame.Dealer.Hand.Last(); //dealer look at dealer card
                    Card playerCard = this._currentGame.Player.Hand.Last(); //dealer look at player card
                    if (dealerCard.Rank == playerCard.Rank) this._currentGame.War();
                    if (dealerCard.Rank > playerCard.Rank) this._currentGame.Winner = this; //dealer is the winner
                    if (dealerCard.Rank < playerCard.Rank) this._currentGame.Winner = _currentGame.Player; //player is the winner
                };
                this._currentGame.HasWinner += (o, winner) =>
                {
                    this._currentGame.Winner = winner;
                    if (winner is Dealer d) {
                        this.Balance += _currentGame.Wager;
                    }
                    else
                    {
                        this.Balance -= _currentGame.Wager;
                        this._currentGame.Player.ReceiveWinning(_currentGame.Wager*2);//if I win, I get double the money (mine+dealer's)
                    };
                    WagerProcessed?.Invoke(this, EventArgs.Empty);
                };
            }

            // | I must implement the abstract method at derived class 
            public override void OnGameOver(object? sender, EventArgs e)
            {
                // | writes the specified string (in this case, "Dealer sees game over") to the Debug Output window, 
                // Logs a message during debugging to help developers track the execution flow or inspect values at runtime.
                Debug.Write("Dealer sees game over"); 
            }
        }

    public class Player(string Name) : Person(Name)
        {
            private WarGame _currentGame;
            private List<WarGame> _gameHistory = new List<WarGame>();
            public int Balance { get; private set; }

            public event EventHandler<EventArgs> DoubleDown;
            public event EventHandler<EventArgs> Surrender;

            public bool ShouldSurrender = false;
            public void JoinGame(WarGame theGame)
            {
                theGame.Player = this;
                this._currentGame = theGame;
                this._currentGame.GotoWar += (o, e) =>
                {
                    if (ShouldSurrender)
                    {
                        Surrender?.Invoke(this, EventArgs.Empty); //either surrender
                    }
                    else
                    {
                        this.Balance -= _currentGame.Wager; //or double the wager
                        DoubleDown?.Invoke(this, EventArgs.Empty);
                    }
                };
            }
        
            public void PlaceBet (int wager)
                {
                    this.Balance -= wager;
                    this._currentGame.Wager = wager;
                }

                public void ReceiveWinning(int winning)
                {
                    this.Balance += winning;
                }

            public override void OnGameOver(object? sender, EventArgs e)
            {
                _gameHistory.Add(_currentGame); //Whenever a game is over, I add the current game to game history
            }

        //| override virtual method HowIFeel from base class Person
        public override string HowIFeel => this.Balance>0? "Feels good" : "Feels bad";
        }
    } 

