using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week04
{
    internal interface IUnaryOperation : IOperation
    {
        double Calculate(double operand);
    }
}
