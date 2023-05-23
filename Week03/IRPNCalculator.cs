using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week03
{
    internal interface IRPNCalculator
    {
        IList<string> OperationsHelpText { get; }
        IList<string> SupportedOperators { get; }
        double Calculate(IList<Token> tokens);
    }
}
