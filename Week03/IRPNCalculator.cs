using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week03;

namespace Week02
{
    internal interface IRPNCalculator
    {
        IList<IOperation> Operations { get; }
        double Calculate(IList<Token> tokens);
    }
}
