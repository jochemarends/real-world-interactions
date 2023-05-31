using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week04
{
    internal class Subtraction : IBinaryOperation
    {
        public string Operator => "-";
        public string Info => "Subtracts the second number from the first one.";
        public double Calculate(double left, double right) => left - right;
    }
}
