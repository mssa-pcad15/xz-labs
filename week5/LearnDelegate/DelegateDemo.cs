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
        public double Multiply(double x, double y) => x * y;
        public double Divide(double x, double y) => x / y;

       
    }

    public delegate double MathOps(double a, double b);
}
