using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week02
{
    internal class RPNCalculator
    {
        private List<string> operators = new List<string>()
        {
            "+", "-", "*", "/", "sqrt"
        };

        public List<string> Operators => operators;

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
                    switch (token.Value)
                    {
                        case "+":
                            stack.Push(stack.Pop() + stack.Pop());
                            break;
                        case "-":
                            // Subtraction is not commutative.
                            double right = stack.Pop(), left = stack.Pop();
                            stack.Push(left - right);
                            break;
                        case "*":
                            stack.Push(stack.Pop() * stack.Pop());
                            break;
                        case "/":
                            // Division is not commutative.
                            double den = stack.Pop(), num = stack.Pop();
                            stack.Push(num / den);
                            break;
                        case "sqrt":
                            stack.Push(Math.Sqrt(stack.Pop()));
                            break;
                    }
                }
            }
        }
    }
}
