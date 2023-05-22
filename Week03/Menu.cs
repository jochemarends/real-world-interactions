using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week03
{
    internal class Menu : IMenu
    {
        private readonly IList<IOperation> operations;

        public Menu(IList<IOperation> operations) => this.operations = operations;

        public void ShowMenu()
        {
            Console.WriteLine("Reverse Polish Notation (RPN) Calculator");
            Console.WriteLine("Enter a valid RPN expression to show the result.");
            Console.WriteLine("Enter 'h' for help.");
            Console.WriteLine("Enter 'o' for the available operators.");
            Console.WriteLine("Enter 'q' to quit.");
        }

        public void ShowHelp()
        {
            Console.WriteLine("The Reverse Polish Notation (RPN) is a mathematical notation in which every operator follows all of its operands.");
            Console.WriteLine("For example, the expression \"a + b\" is written as \"a b +\".");
        }

        public void ShowOperations()
        {
            const int alignWidth = 6;
            foreach (IOperation operation in operations)
            {
                Console.WriteLine($"{$"'{operation.Operator}'", alignWidth} {operation.Info}");
            }
        }
    }
}
