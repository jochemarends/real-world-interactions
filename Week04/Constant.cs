using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week04
{
    internal class Constant : INullaryOperation
    {
        public string Operator { get; private set; }
        public string Info { get; private set; }
        public double Value { get; private set; }

        public Constant(string symbol, string info, double value)
        { 
            Operator = symbol;
            Info = info;
            Value = value;
        }
    }
}
