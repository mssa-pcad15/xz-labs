using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fundamentals;

namespace FundamentalsTest
{
    [TestClass] //this is called attribute (aka. annotation), it is used to describe the class as it contains test to be run
    /*
     1) We usually make test class public, there is another class called test runner, it needs to see this test class
     2) By convention, this class contains methods to test calculator class
     3) Every test should have 4 stages: Arrange, Act, Assert
     4) When write the method, such as Calculator.Add, prevent writing full code other than fixing the compile error first. 
     */
    public class CalculatorTest 
    {
        [TestMethod]
        public void AddTwoPositiveIntegerShouldReturnPositiveResult()
        {
            //Arrange
            int op1 = 1;
            int op2 = 1;

            //Act
            int actual = Calculator.Add(op1, op2);

            //Assert
            Assert.IsTrue(actual>0);
        }

        [TestMethod]
        public void AddTwoIntegersShouldReturnCorrectResult() { 
            //Arrange
            int op1 = 1;
            int op2 = 1;

            //Act
            int actual = Calculator.Add(op1, op2);

            //Assert
            int expected = 2;
            Assert.AreEqual(actual, expected);
        }
    }
}

//Red -> Green -> Refactor
//Add Calculator class to Fundamentals
//Make it public class
//Add: Using Fundamentals; 

//Second red? Under Add 
//What does the method signature look like?
//  1) plublic method returns an int
//  2) takes in 2 int
//  3) static 