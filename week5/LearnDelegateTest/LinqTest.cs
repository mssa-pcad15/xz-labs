using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnDelegateTest
{
    [TestClass]
    public class LinqTest
    {
        [TestMethod]
        public void LinqTestWhere()
        {
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

            var result = names.Where((string s) =>
                {
                    if (s.Length == 4) return true;
                    else return false;

                }
            );
            Assert.IsTrue(result.Contains("Dick"));
            Assert.IsTrue(result.Contains("Mary"));
            Assert.IsFalse(result.Contains("Jay"));
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
