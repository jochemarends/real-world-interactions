using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week02
{
    internal class BinaryOperator : Operator
    {
        Func<double, double, double> operation;
        public double Invoke(double lhs, double rhs) => operation(lhs, rhs);

        public BinaryOperator(string symbol, string info, Func<double, double, double> operation) : base(symbol, info)
        {
            this.operation = operation;
        }
    }
}
