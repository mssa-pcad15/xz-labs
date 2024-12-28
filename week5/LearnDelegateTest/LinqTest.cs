using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace LearnDelegateTest
{
    [TestClass]
    public class LinqTest
    {
        [TestMethod]
        public void LinqTestWhere()
        {
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

            // | refactor
            var result = names.Where(s => s.Length == 4);
            /*
            var result = names.Where((string s) =>
                {
                    if (s.Length == 4) return true;
                    else return false;

                }
            );
            */
            Assert.IsTrue(result.Contains("Dick"));
            Assert.IsTrue(result.Contains("Mary"));
            Assert.IsFalse(result.Contains("Jay"));
        }

        [TestMethod]
        public void LinqTestWhereWithIndex()
        {
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

            var result = names.Where((s,i) => i<3);//"i" is an index
            
            Assert.IsTrue(result.Contains("Tom"));
            Assert.IsTrue(result.Contains("Dick"));
            Assert.IsTrue(result.Contains("Harry"));
        }



        [TestMethod]
        public void LinqTestOrder()
        {
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

            var result = names.OrderBy(s=>s.Length).ThenBy(s=>s[0]); //ThenBy further sort names in each group after "OrderBy". Here it further sort by each word's first letter

            Assert.IsTrue(result.Last() == "Harry");
            Assert.IsTrue(result.First() == "Jay");
            Assert.AreNotEqual(names[4], result.Last());
        }

        [TestMethod]
        public void TestTakeAndSkip()
        {
            //get all the classes from assembly
            string[] typeNames = 
                (from t in typeof(int).Assembly.GetTypes() select t.Name).ToArray();

            var result = typeNames.Take(5);
            Assert.AreEqual(5, result.Count());

            var resultSkip = typeNames.Skip(5).Take(1);
            var verify = typeNames.Take(6);
            Assert.AreEqual(verify.Last(), resultSkip.First());
        }

        [TestMethod]
        public void TestSelectInLinq()
        {
            var fonts = FontFamily.Families;
            var result = fonts.Take(5).Select(f => f.Name); //gets the first 5 elements from the sequence
            foreach(var name in result)
            {
                Debug.WriteLine(name);
            }
        }

        // | select initial letter, name, length of name
        [TestMethod]
        public void TestSelectNewInLinq()
        {
            var fonts = FontFamily.Families;
            var result = fonts.Take(5).Select
                (
                    //this new keyword creates a new type, this new type has 3 propertities
                    f =>
                    new
                    {
                        InitialLetter = f.Name[0],
                        Name = f.Name,
                        FontNameLength = f.Name.Length
                    }
                );
#pragma warning restore CA1416 // Validate platform compatibility
                              //gets the first 5 elements from the sequence
                foreach(var thing in result) //must use "var" because anonymous class (line 85-90) doesn't have a name
            {
                Debug.WriteLine($"{thing.InitialLetter}, {thing.Name}, {thing.FontNameLength}");
            }
        }

        [TestMethod]
        public void TestGroupingInLinq()
        {
            var fonts = FontFamily.Families;
            var resultDetail = fonts.Select
                (
                    //this new keyword creates a new type, this new type has 3 propertities
                    f =>
                    new
                    {
                        InitialLetter = f.Name[0],
                        Name = f.Name,
                        FontNameLength = f.Name.Length
                    }
                );
#pragma warning restore CA1416 // Validate platform compatibility
            var resultGrouped = resultDetail.GroupBy(anon => anon.InitialLetter); //group by anonbased on their initial letter
            Debug.WriteLine($"There are {resultGrouped.Count()} groups from {resultDetail.Count()} fonts");

            foreach (var thing in resultGrouped) // must use "var" because anonymous class (line 85-90) doesn't have a name
                                                 // each thing in resultGrouped represent 1 group, keyed by initial letter
            {
                Debug.WriteLine($"Letter {thing.Key} has {thing.Count()} fonts."); //each thing is also an IEnumerable, so we can call Count(), thing.key is the distinct 
                                                                                   //value with which the group is formed.
                foreach(var font in thing)
                {
                    Debug.WriteLine($"\t{font.Name}");
                }
            }
        }


        [TestMethod]
        public void TestGarage()
        {
            Garage g = new Garage();
            // | Generic programming allows code to be type-safe, it is safe because I specifies the type
            foreach (Car c in g)
                Debug.WriteLine(c.Name);

            // | Non-generic, it is not type-safe, if non-generic, then use "object" type
            foreach(object obj in g)
            {
                if (obj is Car) { //if the obj is generic, it can be any type, so here I am testing
                                  //if it is a Car type and do the following operation.
                    Debug.WriteLine(((Car)obj).Name);
                }
            }
        }
    }

    /* IEnumerable interface has one method GetEnumerator(), which returns an object that implements
     * IEnumerator interface, 
     
     */
    class Garage : IEnumerable<Car>
    {
        // | nested class
        internal class GarageEnumerator : IEnumerator<Car>
        {
            private Car[] cars;
            private int index = -1;
            // | property
            public Car Current => cars[index];

            // | property
            /* "IEnumerator.Current": indicates that the property is an explicit implementation of the 
             * Current property required by the non-generic IEnumerator interface.
             * Explicit implementation means that the property is only accessible when the object is cast 
             * to the IEnumerator interface.
             */
            object IEnumerator.Current => cars[index]; 

            public GarageEnumerator(Car[] cars)
            {
                this.cars = cars;
            }

            public bool MoveNext()
            {
                if (index >= cars.Length - 1) return false;
                else {
                    index++;
                    return true;
                }
            }

            public void Reset()
            {
                index = -1;
            }

            public void Dispose()
            {
                ;
            }
        }

        private Car[] cars = new Car[5];
        private GarageEnumerator _enumerator;

        public Garage()
        {
            cars[0] = new Car("A");
            cars[1] = new Car("B");
            cars[2] = new Car("C");
            cars[3] = new Car("D");
            cars[4] = new Car("E");
            _enumerator = new GarageEnumerator(this.cars);//pass in cars because we need to iterate through the cars list
        }

        //IEnumerable interface method implementation
        public IEnumerator<Car> GetEnumerator() => _enumerator; //return type: IEnumerator<Car>, which means it returns an object that implements IEnumerator interface
                                                                //for a collection of Car objects.

        /* This is an explicit implementation of IEnumerable interface's GetEnumerator() method, 
           return type is "IEnumerator", 
         */
        IEnumerator IEnumerable.GetEnumerator() => _enumerator;
    }

    class Car (string _name)
    {
        public string Name { get; } = _name;
    }
}
