using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Week04
{
    internal enum TokenType
    {
        Number,
        Operator,
    }

    internal struct Token
    {
        public TokenType Type { get; private set; }
        public string Value { get; private set; }

        public bool IsOperator => Type == TokenType.Operator;
        public bool IsNumber => Type == TokenType.Number;

        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}
