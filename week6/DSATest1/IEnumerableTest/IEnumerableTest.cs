using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSATest.IEnumerableTest
{
    [TestClass]
    public class IEnumerableTest
    {
        [TestMethod]
        public void HowDoesIEnumerableWorks()
        {
            string s = "Hello World";
            /* The GetEnumerator() method is called on the string s. It returns a CharEnumerator, 
             * which is a helper object that allows iteration over the individual characters in the 
             * string.
             * charPointer is a variable, which is assigned the CharEnumerator object returned by 
             * s.GetEnumerator().
             */
            CharEnumerator charPointer = s.GetEnumerator();

            int count = 0;
            char[] outcome = new char[s.Length];
            while (charPointer.MoveNext())
            {
                outcome[count++] = charPointer.Current; //access each element in s
                count++;
            }
            Assert.AreEqual(11, count);
            Assert.AreEqual('H', outcome[0]);
            Assert.AreEqual('e', outcome[1]);

            /* the following two lines are another way to iterate s, are interchangable with line 22 to line 30*/
            int count2 = 0;
            foreach(char achar in s)
            {

            }
        }
    }
}
