using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week04
{
    internal class Menu : IMenu
    {
        private readonly IList<string> operationsHelpText;

        public Menu(IList<string> operationsHelpText) => this.operationsHelpText = operationsHelpText;

        public void ShowMenu()
        {
            Console.WriteLine("Multiple Calculators Program");
            Console.WriteLine("Enter a valid expression to show the result.");
            Console.WriteLine("Enter 'h' for help with the current calculator.");
            Console.WriteLine("Enter 's' to switch calculators");
            Console.WriteLine("Enter 'q' to quit.");
        }

        public void ShowHelp()
        {
            Console.WriteLine("The Reverse Polish Notation (RPN) is a mathematical notation in which every operator follows after all of its operands.");
            Console.WriteLine("For example, the expression \"a + b\" is written as \"a b +\".");
            Console.WriteLine("Supported Operators:");
            Console.WriteLine(string.Join('\n', operationsHelpText));
        }
    }
}
