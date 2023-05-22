using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week03
{
    internal class Addition : IBinaryOperation
    {

        public double Calculate(double left, double right) => left + right;
    }
}
