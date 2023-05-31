using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Week04
{
    internal class RPNCalculator : ICalculator, ICollection<IOperation>
    {
        private readonly IList<IOperation> operations = new List<IOperation>();

        public IList<string> SupportedOperators => operations.Select(operation => operation.Operator).ToList();

        public IList<string> OperationsHelpText
        {
            get
            {
                const int alignWidth = 6;
                Func<IOperation, string> toString = operation => $"{$"'{operation.Operator}'", alignWidth} {operation.Info}";
                return operations.Select(toString).ToList();
            }
        }

        public int Count => operations.Count;
        public bool IsReadOnly => operations.IsReadOnly;

        public double Calculate(IList<Token> tokens)
        {
            Stack<double> stack = new Stack<double>();

            double Pop()
            {
                if (!stack.TryPop(out double number))
                    throw new InvalidOperationException("Too few operands were given.");
                return number;
            }

            foreach (Token token in tokens)
            {
                if (token.IsNumber)
                {
                    stack.Push(double.Parse(token.Value));
                }
                else if (token.IsOperator)
                {
                    IOperation operation = operations.FirstOrDefault(operation => operation.Operator.Equals(token.Value))
                        ?? throw new NotImplementedException($"Operator \"{token.Value}\" is not implemented.");

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

            if (stack.Count != 1) throw new Exception("Unused operand(s).");
            return Pop();
        }

        public void Add(IOperation item) => operations.Add(item);
        public void Clear() => operations.Clear();
        public bool Contains(IOperation item) => operations.Contains(item);
        public void CopyTo(IOperation[] array, int arrayIndex) => operations.CopyTo(array, arrayIndex);
        public IEnumerator<IOperation> GetEnumerator() => operations.GetEnumerator();
        public bool Remove(IOperation item) => operations.Remove(item);
        IEnumerator IEnumerable.GetEnumerator() => operations.GetEnumerator();
    }
}
