using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week02
{
    internal abstract class Operator
    {
        public string Symbol { get; private set; }
        public string Info { get; private set; }

        public Operator(string symbol, string info)
        {
            Symbol = symbol;
            Info = info;
        }
    }
}
