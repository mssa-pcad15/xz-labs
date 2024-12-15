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

            //PolymorphicAnimal();
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


    //create a base abstract class Animal, which contains abstract method MakeNoise
    //create 3 derived child class from Animal, Cat, Dog, Bird
    //implement abstract method to print their noise
    /* Base abstract class */
    abstract class Animal{
         internal abstract void MakeNoise();
         internal string Im { get; set; } 
    }

    /* Derived class Cat */
    class Cat : Animal
    {
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

