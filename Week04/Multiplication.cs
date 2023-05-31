using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week04
{
    internal class Multiplication : IBinaryOperation
    {
        public string Operator => "*";
        public string Info => "Multiplies two numbers.";
        public double Calculate(double left, double right) => left * right;
    }
}
