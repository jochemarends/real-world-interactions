using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week04
{
    internal interface IExpressionEvaluator<T>
    {
        T Evaluate(string expression);
        IList<string> Help { get; }
        string Description { get; }
    }
}
