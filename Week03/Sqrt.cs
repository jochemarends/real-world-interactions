using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week03
{
    internal class Sqrt : IUnaryOperation
    {
        public string Operator => "sqrt";
        public string Info => "Calculates the square root of a number.";
        public double Calculate(double operand) => Math.Sqrt(operand);
    }
}
