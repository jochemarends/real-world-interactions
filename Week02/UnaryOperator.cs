using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week02
{
    internal class UnaryOperator : Operator
    {
        Func<double, double> operation;
        public double Invoke(double operand) => operation(operand);

        public UnaryOperator(string symbol, string info, Func<double, double> operation) : base(symbol, info)
        {
            this.operation = operation;
        }
    }
}
