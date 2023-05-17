using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Week02
{
    internal class RPNCalculator : IRPNCalculator
    {
        public IList<Operator> operators = new List<Operator>();
        public IList<Operator> Operators => operators;

        private double Add(double lhs, double rhs) => lhs + rhs;
        private double Sub(double lhs, double rhs) => lhs - rhs;
        private double Mul(double lhs, double rhs) => lhs * rhs;
        private double Div(double lhs, double rhs) => lhs / rhs;

        public RPNCalculator()
        {
            operators.Add(new BinaryOperator("+", "Addition", Add));
            operators.Add(new BinaryOperator("-", "Subtraction", Sub));
            operators.Add(new BinaryOperator("*", "Multiplication", Mul));
            operators.Add(new BinaryOperator("/", "Division", Div));
            operators.Add(new UnaryOperator("sqrt", "Square root", Math.Sqrt));

            Dictionary<string, int> dict = new();
            dict.First()
        }

        private Operator? GetOperator(string symbol)
        {
            return Operators.FirstOrDefault(op => op.Symbol == symbol);
        }

        public void Calculate(List<Token> tokens)
        {
            Stack<double> stack = new Stack<double>();

            foreach (Token token in tokens)
            {
                if (token.IsNumber)
                {
                    stack.Push(double.Parse(token.Value));
                }
                else if (token.IsOperator)
                {
                    Operator op = GetOperator(token.Value) ?? throw new NotImplementedException($"Operator {token.Value} is not implemented.");

                    if (op is UnaryOperator unaryOperator)
                    {
                        unaryOperator.Invoke(stack.Pop());
                    }
                    else if (op is BinaryOperator binaryOperator)
                    {
                        double rhs = stack.Pop();
                        double lhs = stack.Pop();
                        binaryOperator.Invoke(lhs, rhs);
                    }
                }
            }
        }
    }
}
