using Fundamentals1.LearnTypes1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundamentalsTest1
{
    [TestClass]
    internal class LearnClassTest1
    {
        [TestMethod]
        public void InstanceMemberExistsForEachInstance()
        {
            //Arrange
            LearnClass1 obj1 = new LearnClass1(DateTime.Now);
            LearnClass1 obj2 = new LearnClass1(DateTime.Now);

            //Act
            obj1.InstanceMember = 200;
            obj2.InstanceMember = 300;

            //Assert
            Assert.IsTrue(obj1.InstanceMember != obj2.InstanceMember);
            Assert.AreNotSame(obj1, obj2); //AreNotSame test if two objs points to the same location


        }

        [TestMethod]
        public void EachInstanceHasTheirOwnData()
        {
            //Arrange, Act
            LearnClass1 victor = new LearnClass1(new DateTime(1900, 5, 5), "password");
            LearnClass1 bob = new LearnClass1(new DateTime(1970, 3, 5), "password2");
            LearnClass1 tom = new LearnClass1(new DateTime(2012, 3, 5), "password3");
            LearnClass1 anotherVictor = victor;

            //Assert
            Assert.AreNotSame(victor, bob);
            Assert.AreNotSame(bob, tom);
            Assert.AreSame(anotherVictor, victor);
        }

        [TestMethod]
        public void ShowCorrectAgeGivenADob()
        {
            //Arrange
            LearnClass1 victor = new LearnClass1(new DateTime(1900, 5, 5), "password");

            //Act
            int actual = victor.Age;
            int expected = 34;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShowPasswordCanChange()
        {
            LearnClass1 victor = new LearnClass1(new DateTime(1900, 5,5), "password");
            victor.Password = "newPassword";
            Assert.IsTrue(victor.VerifyPassword("newPassword"));
        }

    }
}
