using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week03
{
    internal class NaturalLogarithm : IUnaryOperation
    {
        public string Operator => "ln";
        public string Info => "Calculates the natural logarithm of a number.";
        public double Calculate(double operand) => Math.Log(operand);
    }
}
