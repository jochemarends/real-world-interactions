using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week02
{
    internal class Menu : IMenu
    {
        private readonly IList<string> operationsHelpText;
        public Menu(IList<string> operationsHelpText) => this.operationsHelpText = operationsHelpText;

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

        public void ShowOperations() => Console.WriteLine(string.Join('\n', operationsHelpText));
    }
}
