using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week03
{
    internal interface INullaryOperation : IOperation
    {
        double Value { get; }
    }
}
