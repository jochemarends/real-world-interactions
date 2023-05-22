using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week03
{
    internal class Exponentation : IBinaryOperation
    {
        public string Operator => "^";
        public string Info => "Raises the first number by the power of the second one.";
        public double Calculate(double left, double right) => Math.Pow(left, right);
    }
}
