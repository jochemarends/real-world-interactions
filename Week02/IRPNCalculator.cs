﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week02
{
    internal interface IRPNCalculator
    {
        IList<string> Operators { get; }
        IList<string> OperationsHelpText { get; }

        double Calculate(IList<Token> tokens);
    }
}
