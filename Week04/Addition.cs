using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week04
{
    internal class Addition : IBinaryOperation
    {
        public string Operator => "+";
        public string Info => "Adds two numbers.";
        public double Calculate(double left, double right) => left + right;
    }
}
