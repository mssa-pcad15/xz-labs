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
            Assert.IsTrue(delegateInstance.Method.Name == "Multiply");//delegate.Method represent the runtime method this instance points to
            Assert.IsTrue(delegateInstance.Method.GetParameters().Length == 2); //two parameters that passed into "Multiply()" method

        }

        [TestMethod]
        public void InstantiateADelegateAndInvoke()
        {
            DelegateDemo d = new DelegateDemo();
            MathOps delegateInstance = d.Multiply;

            /*###### 
             * delegates have an Invoke() method that allows you to "explicitly" call the method(s) referenced by the 
             * delegate. However, in most cases, you don't need to use Invoke() explicitly because delegates can be called 
             * like regular methods.  
             ###### */
            double result = delegateInstance.Invoke(5, 6);
            double expected = 30;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PassADelegateAsArgumentToMethod()
        {
            DelegateDemo d = new DelegateDemo();
            MathOps delegateInstance = d.Multiply;

            double result = InvokeThis(delegateInstance); //We have passed this data into a method many times, now let's see pass instruction into a method
            double expected = 30;
            Assert.AreEqual(expected, result);
        }

        public double InvokeThis(MathOps instance) //this method invokes parameter delegate MathOps without knowing the implementing method, the only thing it knows it
                                                   //will take two doubles and return a double
        {
            return instance.Invoke(5, 6);
        }

        public void InvokeThis(VoidMathOps instance)
        {
            instance.Invoke(5, 6);
        }

        [TestMethod]
        /* multicasting delegate are usually for methods with no return value because of the issue of only the last method
         * is returned 
         */
        public void DelegateVariableSupportsMulticasting()
        {
            DelegateDemo d = new DelegateDemo();
            /* "=" vs "+=": if use "=" on "delegateInstance = d.Divide;" then Divide will override Multiply */
            MathOps delegateInstance = d.Multiply;
            delegateInstance += d.Divide;  //I want delegate variable "delegateInstance" point to multiple things, so I need to piggyback using +=

            double result = InvokeThis(delegateInstance);
            //double expected = 30;
            //Assert.AreEqual(expected, result); -- the last delegate variable will be invoked, which is "Divide"
            Assert.AreEqual(result, 5.0 / 6);
            Assert.IsTrue(delegateInstance.GetInvocationList().Length == 2);
            Assert.IsTrue(delegateInstance.GetInvocationList()[0].Method.Name == nameof(d.Multiply));
            Assert.IsTrue(delegateInstance.GetInvocationList()[1].Method.Name == nameof(d.Divide));
        }

        [TestMethod]
        public void MulticastDelegateShouldUseVoidReturnAndAccessResultsAsStateElseWhere()
        {
            DelegateDemo d = new DelegateDemo();
            VoidMathOps delegateInstance = d.VoidMultiply;
            delegateInstance += d.VoidDivide;

            InvokeThis(delegateInstance);

            Assert.IsTrue(d.Results.Contains(5.0 / 6));
            Assert.IsTrue(d.Results.Contains(5 * 6));
            Assert.IsTrue(delegateInstance.GetInvocationList().Length == 2);
            Assert.IsTrue(delegateInstance.GetInvocationList()[0].Method.Name == nameof(d.VoidMultiply));
            Assert.IsTrue(delegateInstance.GetInvocationList()[1].Method.Name == nameof(d.VoidDivide));

        }
    }
}