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

            var result2 = bagOfNumbers.PickItems((i) => i%2==0 );
            Assert.AreEqual(500, result2.Count());
        }

    }

    public delegate bool delFilter<T>(T input);
    public static class MyExtensions{
        /* 
           The <T> in PickItems<T> explicitly ties the generic behavior of the extension method to the type of the collection (IEnumerable<T>).
           Without <T>, the compiler wouldn't know how to infer the type of the method parameters (like filter) or the return type. 
        */
        public static IEnumerable<T> PickItems<T>(this IEnumerable<T> values, delFilter<T> filter) {
            foreach (var item in values)
                if (filter(item)) yield return item;
            
        }
}

}
