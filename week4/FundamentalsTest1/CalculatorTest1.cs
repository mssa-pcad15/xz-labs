using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fundamentals1;

namespace FundamentalsTest1
{
    /*
     1) We usually make test class public, there is another class called test runner, it needs to see this test class
     2) By convention, this CalculatorTest1 class contains methods to test calculator class
     3) Every test should have 3 stages: Arrange, Act, Assert
     4) When write the method, such as Calculator.Add, prevent writing full code other than fixing the compile error first. 
     */

    [TestClass] //this is called attribute (aka. annotation), it is used to describe the class as it contains test to be run
    public class CalculatorTest1 //Make it public so the Test Runner can see this class
    {
        [TestMethod]
        public void AddTwoPositiveIntegerShouldReturnPositiveResule()
        {
            //Arrange -- arrange sth. to be tested
            int op1 = 1;
            int op2 = 1;

            //Act -- act is when we exercise a method and receive a result
            int actual = Calculator1.Add(op1, op2);

            //Assert -- assert confirms the correctness of the method
            Assert.IsTrue(actual > 0);
        }

        [TestMethod]
        public void AddTwoIntegersShouldReturnCorrectResult()
        {
            //Arrange
            int op1 = 1;
            int op2 = 1;

            //Act
            int actual = Calculator1.Add(op1, op2);

            //Assert
            int expected = 2;
            Assert.AreEqual(expected, actual);
        }


    }
}
//Red -> Green -> Refactor -- In test driven environment, only write bare minimum code to make red turn green.
//And there are 2 types of Red, compile time and run time. First address compile time then run time.
//1. Add Calculator class to Fundamentals
//2. Make it public class
//3. Add: Using Fundamentals; (the namespace, which is added to the top of CalculatorTest1.cs 



//Second red? Under Add 
//What does the method signature look like?
//  1) plublic method returns an int, and must be called Add
//  2) takes in 2 int
//  3) static 