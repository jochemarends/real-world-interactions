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
        private readonly IList<string> operators = new List<string>()
        {
            "+", "-", "*", "/", "^", "sqrt", "exp", "ln"
        };

        private readonly IList<string> operationsHelpText = new List<string>()
        {
            "Operators:",
            "   '+' Adds two numbers.",
            "   '-' Subtracts two numbers.",
            "   '*' Multiplies two numbers.",
            "   '/' Divides the first number by the second one.",
            "   '^' Raises the first number by the power of the second one.",
            "'sqrt' Calculates the square root of a number.",
            " 'exp' Raises a the exponential constant by the power of a number.",
            "  'ln' Calculates the natural logarithm of a number."
        };

        public IList<string> Operators => operators;
        public IList<string> OperationsHelpText => operationsHelpText;

        public double Calculate(IList<Token> tokens)
        {
            Stack<double> stack = new Stack<double>();

            foreach (var token in tokens)
            {
                if (token.IsNumber)
                {
                    stack.Push(double.Parse(token.Value));
                }
                else if (token.IsOperator)
                {
                    switch (token.Value)
                    {
                        case "+":
                            stack.Push(Pop() + Pop());
                            break;
                        case "-":
                            // Subtraction is not commutative.
                            double rhs = Pop();
                            double lhs = Pop();
                            stack.Push(lhs - rhs);
                            break;
                        case "*":
                            stack.Push(Pop() * Pop());
                            break;
                        case "/":
                            // Division is not commutative.
                            double den = Pop();
                            double num = Pop();
                            stack.Push(num / den);
                            break;
                        case "^":
                            // Exponentation is not commutative.
                            double exponent = Pop();
                            double @base = Pop();
                            stack.Push(Math.Pow(@base, exponent));
                            break;
                        case "sqrt":
                            double operand = Pop();
                            if (operand < 0) throw new ArgumentException("Can't take the square root of a negative number");
                            stack.Push(Math.Sqrt(operand));
                            break;
                        case "exp":
                            stack.Push(Math.Exp(Pop()));
                            break;
                        case "ln":
                            stack.Push(Math.Log(Pop()));
                            break;
                        default:
                            throw new NotImplementedException($"Operator {token.Value} is not implemented.");
                    }
                }
            }

            if (stack.Count != 1) throw new Exception("Unused operand(s).");
            return Pop();

            double Pop()
            {
                if (!stack.TryPop(out double number))
                    throw new InvalidOperationException("Too few operands are given");
                return number;
            }
        }
    }
}
