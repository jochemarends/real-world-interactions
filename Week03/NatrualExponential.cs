using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week03
{
    internal class NaturalExponential : IUnaryOperation
    {
        public string Operator => "exp";
        public string Info => " Raises a the exponential constant by the power of a number.";
        public double Calculate(double operand) => Math.Exp(operand);
    }
}
