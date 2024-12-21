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
        public double Multiply(double x, double y) => x * y; //this method fits delegate description, because it takes two
                                                             //doubles and returns a double
        public double Divide(double x, double y) => x / y; //this method fits delegate description, because it takes two
                                                           //doubles and returns a double


    }

    /* 
        A delegate named MathOps is declared, which can "reference" any method that:
        - Takes two double parameters.
        - Returns a double. 
    */
    public delegate double MathOps(double a, double b);
}
