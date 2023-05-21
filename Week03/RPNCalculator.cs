﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Week03;

namespace Week02
{
    internal class RPNCalculator : IRPNCalculator
    {
        private readonly IList<IOperation> operations = new List<IOperation>();

        public IList<IOperation> Operations => operations;

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
                    IOperation operation = operations.FirstOrDefault(operation => operation.Symbol.Equals(token.Value))
                        ?? throw new NotImplementedException($"Operator {token.Value} is not implemented.");

                    switch(operation)
                    {
                        case INullaryOperation nullaryOperation:
                            stack.Push(nullaryOperation.Value);
                            break;
                        case IUnaryOperation unaryOperation:
                            double operand = Pop();
                            stack.Push(unaryOperation.Calculate(operand));
                            break;
                        case IBinaryOperation binaryOperation:
                            double right = Pop(), left = Pop();
                            stack.Push(binaryOperation.Calculate(left, right));
                            break;
                    }
                }
            }

            return Pop();

            double Pop()
            {
                if (!stack.TryPop(out double number))
                    throw new InvalidOperationException("Too few operands were given");
                return number;
            }
        }
    }
}