using LearnDelegate;
using System.Transactions;

namespace LearnDelegateTest
{
    [TestClass]
    public class DelegateDemoTest
    {
        [TestMethod]
        public void InstantiateADelegate()
        {
            DelegateDemo d = new DelegateDemo(); //d is a variable of class, so points to an instance
            MathOps delegateInstance = d.Multiply; //delegateInstance is a  point to d.Multiply method
            Assert.IsTrue(delegateInstance.Method.Name == "Multiply");
            Assert.IsTrue(delegateInstance.Method.GetParameters().Length == 2);

        }

        [TestMethod]
        public void InstantiateADelegateAndInvoke() {
            DelegateDemo d = new DelegateDemo();

            MathOps delegateInstance = d.Multiply;

            double result = delegateInstance.Invoke(5, 6);
            double expected = 30;
            Assert.AreEqual(expected, result);
        
        }
    }
}