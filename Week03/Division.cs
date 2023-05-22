using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week03
{
    internal class Division : IBinaryOperation
    {
        public string Operator => "/";
        public string Info => "Divides the first number by the second one.";
        public double Calculate(double left, double right) => left / right;
    }
}
