using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace TimerDemoNameSpace
{
    public class SlowCalculator
    {
        public event EventHandler<int> ResultDone; //this is an event declaration 
        public string Name { get; set; }


        // | constructor
        public SlowCalculator(string name)
        {
            Name = name;
        }

        public void Add(int x, int y)
        {
            Thread.Sleep(3000);
            //ResultDone?.Invoke(this, new EventArgs());
            ResultDone?.Invoke(this, x + y); //this is an event waiting to be invoked
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //TimerDemo();

            //EventHandlingDemo();

           //"Here is a sentence".Where((char aChar) => true);

            /* IEnumerable, Linq */
            // | Call Where method on a string, iterate each char, checks whether the character is in the string "aeiou" by calling .Contains(), if any aChar exist
            // then returns true, else false and the char is filtered out.
           string result = new string("Here is a sentence".Where( (char aChar) => "aeiou".Contains(aChar)).ToArray() );

            // | Where() method in Linq has other overloads, this is the second overload, index already automatically refers to "array index" in this second overload
            string result1 = new string("Here is a sentence".Where((char aChar, int index) => index % 2 == 0).ToArray());
        }
        //calc.ResultDone += (Object obj, EventArgs<int> e) => Console.WriteLine($"Result is calculated");
        /*
         calc.ResultDone += (Object obj, int e) => Console.WriteLine($"Result is {e}");//here, we invoked the event
         calc.Add(6, 6);
        */

        //object that raises the event passes itself as the sender argument.
        private static void handleEvent(object? sender, int e)
        {
            SlowCalculator c = sender as SlowCalculator; //cast sender object to SlowCalculator type
            Console.WriteLine($"{c.Name} is finished, answer is {e}"); //the sender let one event handler handle multiple events
        }

        static void EventHandlingDemo()
        {
            SlowCalculator calc = new SlowCalculator("calc");
            SlowCalculator calc1 = new SlowCalculator("calc1");
            SlowCalculator calc2 = new SlowCalculator("calc2");
            calc.ResultDone += handleEvent; //call event handler, ResultDone is publisher, handleEvent is subscriber
            calc1.ResultDone += handleEvent;
            calc2.ResultDone += handleEvent;
            calc.Add(6, 6);
            calc1.Add(3, 8);
            calc2.Add(7, 8);
        }


        private static void TimerDemo()
        {
            System.Timers.Timer timer = new System.Timers.Timer(); //instantiate a timer

            timer.Elapsed += Timer_Elapsed; //Timer_Elapsed is an event


            timer.Interval = 10000; //10 seconds
            timer.Start();
            Console.WriteLine("Please enter to end the program");
            Console.ReadLine();
        }

        // | the following can be combined using lambda expression: timer.Elapsed += (object? sender, System.Timers.ElapsedEventArgs e)=>Console.WriteLine($"Timer rang, {e.SignalTime}");
        private static void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        { //event execution area
            Console.WriteLine($"Timer rang, {e.SignalTime}");
        }
    }
}

