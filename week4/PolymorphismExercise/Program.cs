using System.Security.Cryptography;
using System.Text;

namespace PolymorphismExercise
{
    class Program // Default access modifier is `internal`

    {
        static void Main(string[] args)
        {
            /* Convert a string HelloWorld into hash */
            string originalText = "Hello World";
            byte[] dataArray = Encoding.UTF8.GetBytes(originalText); //convert string to byte
            HashAlgorithm sha = SHA256.Create(); //Creates an instance of the default implementation of SHA256.
            byte[] result = sha.ComputeHash(dataArray); //Computes the hash value for the specified Stream object.

            // | Convert is a System namespace class. It provides static methods to convert base data types to other type.
            // Commonly used for encoding and decoding operations, like converting between byte arrays and Base64-encoded strings.
            var base64EncodedResult = Convert.ToBase64String(result);
            Console.WriteLine(base64EncodedResult);

            /*  test the extension methods */
            String s = "Hello World, this is a good day.";
            var resultString = s.Reverse().ThenTakeEvenLetters().ThenPutSpaceBetweenLetters().ThenCapitalizeTheString();
            foreach (var item in resultString) {
                Console.WriteLine(item);
            }

            //PolymorphicAnimal();

            /* call ToHash() extension method */
            String s2 = "Hello World, this is a good day.";
            Console.WriteLine($"{s2.ToHash()} using default algo");
            Console.WriteLine($"{s2.ToHash(SHA512.Create())} using SHA512 algo");
            Console.WriteLine($"{s2.ToHash(SHA256.Create())} using SHA256 algo");

            /* call HowManyDaysToBirthday() extension method */
            DateTime today = DateTime.Now;
            if (today.HowManyDaysToBirthday() > 100)
                Console.WriteLine("So far away...");
            else Console.WriteLine("It's around the corner");
        }

        private static void PolymorphicAnimal()
        {
            System.Random rand = new Random();
            List<Animal> animals = new List<Animal>(); //List<Animal> store reference to Animal and its derived instances
            for (int i = 0; i < 5; i++)
            {
                switch (rand.Next(100) % 3) //Next(100): 0-99, modula 3 result in 0,1,2 because the only possible
                                            // remainder when divide by 3 is 0,1,2
                {
                    case 0:
                        animals.Add(new Cat() { Im = "Cat" }); //object initializer for property value
                        break;
                    case 1:
                        animals.Add(new Dog() { Im = "Dog" });
                        break;
                    case 2:
                        animals.Add(new Bird() { Im = "Bird" });
                        break;
                    default:
                        break;
                }
            }
            foreach (Animal animal in animals)
            {
                animal.MakeNoise();
            }
        }
    }

    /*
    Reverse() method is an extension method from System.Linq namespace
    */
    /* Showcase an extension method that extends IEnumerable of char */
    /*
     Using `IEnumerable<char>` allows “Lazy Evaluation”. Here, the “ThenTakeEvenLetters” method does not process all elements upfront. 
    This is efficient for **large data sets** or **streams of data**, as only the required elements are evaluated.
    VS Collection, if the input were a `List<char>` (a collection), all elements would need to be stored and processed upfront.
     */
    static class MyExtensionMethods
    {
        public static IEnumerable<char> ThenTakeEvenLetters(this IEnumerable<char> input)
        {
            int counter = 0;
            foreach (char c in input) //go through each letter one by one
            {
                //the yield return keyword in C# is used in iterators to return one element at a time to the caller without requiring the entire collection to be created in memory.
                if (counter % 2 == 0) yield return c;
                counter++;
            }
        }

        public static IEnumerable<char> ThenPutSpaceBetweenLetters(this IEnumerable<char> input)
        {
            foreach (char c in input) //go through each letter one by one
            {
                //the yield return keyword in C# is used in iterators to return one element at a time to the caller without requiring the entire collection to be created in memory.
                yield return c;
                yield return ' ';
            }
        }

        public static IEnumerable<char> ThenCapitalizeTheString(this IEnumerable<char> input)
        {
            foreach (char c in input) //go through each letter one by one
            {
                //The String(char c, int count) constructor creates a string containing the character c repeated count times.
                //Here, it creates a new string instance by repeating the character c exactly 1 time.
                //[0]: Retrieves the first character (at index 0) of the uppercase string. Since new String(c, 1) produces a string with
                //only one character, ToUpper() will also produce a single-character string, and [0] accesses that single character.
                yield return new String(c, 1).ToUpper()[0];
            }
        }

        public static string ToHash(this string s, HashAlgorithm? algo=null)//extends string class on s, and accept an algo
        {
            algo ??= MD5.Create(); //if algo is null, assgin value from MD5.Create.
                                   //if algo is not null, keep algo's original value
            byte[] hashBytes = algo.ComputeHash(Encoding.UTF8.GetBytes(s));
            return Convert.ToBase64String(hashBytes);
        }

        public static int HowManyDaysToBirthday(this DateTime theDate, int month = 12, int day = 25)
        {
            DateTime thisYearBirthday = new DateTime(DateTime.Now.Year, month, day);
            if (theDate > thisYearBirthday)//If theDate (which is "today") is already after thisYearBirthday
            {
                DateTime nextBirthday = new DateTime(DateTime.Now.Year + 1, month, day);
                return nextBirthday.Subtract(theDate).Days;
            }
            else
                return thisYearBirthday.Subtract(theDate).Days;

        }
    }



    //create a base abstract class Animal, which contains abstract method MakeNoise
    //create 3 derived child class from Animal, Cat, Dog, Bird
    //implement abstract method to print their noise
            /* Base abstract class */
    abstract class Animal{

        //fully implemented property
        private int myVar; //private backing field

        public int MyProperty //public property
        {
            get { return myVar; }
            set { myVar = value; }
        }

        //init property
        public int ThisCanBeSetByConstructor { get; init; }

        internal abstract void MakeNoise();
         internal string Im { get; set; } 
    }

    /* Derived class Cat */
    class Cat : Animal
    {

        public Cat()
        {
            this.ThisCanBeSetByConstructor = 5; //use constructor to initialize property value, once assigned, can't be changed
        }
        internal override void MakeNoise()
        {
            Console.WriteLine("Meow");
        }
    }

    /* Derived class Dog */
    class Dog : Animal
    {
        internal override void MakeNoise()
        {
            Console.WriteLine("Woof");
        }
    }

    /* Derived class Bird */
    class Bird : Animal
    {
        internal override void MakeNoise()
        {
            Console.WriteLine("PioPio");
        }
    }
}

