using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Week04
{

    internal class Parser : IParser
    {
        private readonly IEnumerable<string> supportedOperators;

        public Parser(IEnumerable<string> supportedOperators) => this.supportedOperators = supportedOperators;

        public IList<Token> Tokenize(string input)
        {
            IList<Token> tokens = new List<Token>();
            
            foreach (string @string in input.Split().Where(@string => !string.IsNullOrEmpty(@string)))
            {
                if (supportedOperators.Contains(@string))
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
