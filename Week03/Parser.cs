using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week02
{

    internal class Parser : IParser
    {
        private readonly IRPNCalculator calculator;

        public Parser(IRPNCalculator calculator) => this.calculator = calculator;

        public IList<Token> Tokenize(string input)
        {
            IList<Token> tokens = new List<Token>();

            foreach (string @string in input.Split())
            {
                if (calculator.Operators.Contains(@string))
                {
                    tokens.Add(new Token(TokenType.Operator, @string));
                }
                else if (double.TryParse(@string, out _))
                {
                    tokens.Add(new Token(TokenType.Number, @string));
                }
                else
                {
                    throw new ArgumentException($"Failed to tokenize \"{@string}\".");
                }
            }

            return tokens;
        }
    }
}
