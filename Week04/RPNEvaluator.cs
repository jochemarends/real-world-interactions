using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week04
{
    internal class RPNEvaluator : IExpressionEvaluator<double>
    {
        public ICalculator Calculator { get; set; }
        public IParser Parser { get; set; }

        private IList<string> help = new List<string>()
        {
            "RPN is a mathematical notation in which every operator follows after all of its operands.",
            "For example, the expression \"a + b\" is written as \"a b +\".",

        }

        public RPNEvaluator(ICalculator calculator, IParser parser)
        {
            Calculator = calculator;
            Parser = parser;
        }

        public double Evaluate(string expression)
        {
            IList<Token> tokens = Parser.Tokenize(expression);
            return Calculator.Calculate(tokens);
        }

        public IList<string> Help
        {
            get
            {
                List<string> helpText = new()
                {
                    "RPN is a mathematical notation in which every operator follows after all of its operands.",
                    "For example, the expression \"a + b\" is written as \"a b +\".",
                };

                helpText.AddRange(Calculator.OperationsHelpText);
                return helpText;
            }
        }

        public string Description => "Reverse Polish Notation (RPN) Calculator";
    }
}
