using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LearnDelegateTest
{
    [TestClass]
    public class DelegateInDotNetTest
    {
        [TestMethod]
        public void PickItemFromCollectionTest()
        {
            IEnumerable<int> bagOfNumbers = Enumerable.Range(1, 1000);

            // call extension methods
            var result = bagOfNumbers.PickItems((i) => false);
            Assert.AreEqual(0, result.Count());

            var result2 = bagOfNumbers.PickItems((i) => i % 2 == 0);
            Assert.AreEqual(500, result2.Count());
        }

        [TestMethod]
        public void PickPersonFromCollectionTest()
        {
            Person[] people =
            {
               new Person ("Alice", 35),
               new Person ("Bob", 25),
               new Person ("Charlie", 45),
            };

            /* ################ Step 3: Use delegate declaration ################### */
            // | count people whose age is over 30
            var result = people.PickItems(p => p.Age > 30);
            Assert.AreEqual(2, result.Count()); //The Count() method (from LINQ) is called on this sequence to count how many items it contains.

            // | find name starts with A
            var initialResult = people.PickItems(p => p.Name.StartsWith('A'));
            Assert.AreEqual(1, initialResult.Count());
            Assert.AreEqual("Alice", initialResult.First().Name);

            // | find name length > 5
            var nameLength = people.PickItems(p => p.Name.Length > 5);
            Assert.AreEqual(1, nameLength.Count());
            Assert.AreEqual("C", nameLength.First().Name);
            /* ################## Use delegate declaration ################## */

        }



        [TestMethod]
        /* ################### Use Func delegate #######################*/
        public void PickPersonFromCollectionUsingLinqTest() {
            Person[] people =
            {
                new Person("Alice", 35),
                new Person("Bob", 25),
                new Person("Charlie", 45)
            };
            // | where age is over 30
            var result = people.Where(p => p.Age > 30); //no need to call PickItems explicitly, because I am using LINQ's built-in Where method,
                                                        //which serves the same purpose as your custom PickItems extension method.
            Assert.AreEqual(2, result.Count()); //The Count() method (from LINQ) is called on this sequence to count how many items it contains.

            // | where name starts with A
            var initialResult = people.Where(p => p.Name.StartsWith('A'));
            Assert.AreEqual(1, initialResult.Count());
            Assert.AreEqual("Alice", initialResult.First().Name);

            // | where name length > 5
            var nameLength = people.Where(p => p.Name.Length > 5);
            Assert.AreEqual(1, nameLength.Count());
            Assert.AreEqual("Charlie", nameLength.First().Name);
        }
    }

    class Person(String Name, int Age) //primary constructor
    {
        public string Name { get; } = Name;
        public int Age { get; } = Age;
    }

    //###### | the following delegate declaration can be omit when using Func delegate
    /* ################ Step 1. Delegate Declaration#############  */
    /*
       public delegate bool delFilter<T>(T input);
    */
    /* ################ Delegate Declaration############# */



    public static class MyExtensions
    {

        /* ################# Step 2: extension method using delegate declaration ############### */
        /* 
           The <T> in PickItems<T> explicitly ties the generic behavior of the extension method to the type of the collection (IEnumerable<T>).
           Without <T>, the compiler wouldn't know how to infer the type of the method parameters (like filter) or the return type. 
        */
        /*
        public static IEnumerable<T> PickItems<T>(this IEnumerable<T> values, delFilter<T> filter) {
            foreach (var item in values)
                if (filter(item)) yield return item; //The yield return item inside the PickItems extension method adds each matching item to the
                                                     //resulting sequence.
                                                     //However, the yield return itself does not directly return a count—it creates an IEnumerable<T>
                                                     //sequence, which generates items one by one as they are iterated.
        }
        */
        /* ################# extension method using delegate declaration ############### */


        /* ############## Use Func delegate, delegate declaration can be omitted ################ */
        public static IEnumerable<T> PickItems<T>(this IEnumerable<T> values, Func<T, bool> filter)
        {
            foreach (var item in values)
                if (filter(item)) yield return item;
        }

    }
}
