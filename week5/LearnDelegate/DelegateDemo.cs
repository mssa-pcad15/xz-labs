using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnDelegate
{
    //Question: Whata things can be defined under namespace?
    //
    public class DelegateDemo
    {
        public List<double> Results = new List<double>(); //not a property, it is a public field
        public double Multiply(double x, double y) => x * y; //this method fits delegate description, because it takes two
                                                             //doubles and returns a double
        public double Divide(double x, double y) => x / y; //this method fits delegate description, because it takes two
                                                           //doubles and returns a double
        
        public void VoidMultiply(double x, double y) => this.Results.Add(x * y);
        public void VoidDivide(double x, double y) => this.Results.Add(x/ y);
    }

    /* 
        A delegate named MathOps is declared, which can "reference" any method that:
        - Takes two double parameters.
        - Returns a double. 
    */
    public delegate double MathOps(double a, double b);

    public delegate void VoidMathOps(double a, double b); //must create this delegate to accommodate the void type method 
}
