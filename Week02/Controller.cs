using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Week02
{
    internal class Controller
    {
        private readonly IRPNCalculator calculator;
        private readonly IParser parser;
        private readonly IMenu menu;

        public Controller(IRPNCalculator calculator, IParser parser, IMenu menu)
        {
            this.calculator = calculator;
            this.parser = parser;
            this.menu = menu;
            menu.ShowMenu();
        }

        public void Run()
        {
            string input;
            do
            {
                Console.Write("> ");
                input = Console.ReadLine() ?? "q";
                switch (input)
                {
                    case "q":
                        break;
                    case "h":
                        menu.ShowHelp();
                        break;
                    case "o":
                        menu.ShowOperations();
                        break;
                    default:
                        try
                        {
                            IList<Token> tokens = parser.Tokenize(input);
                            double result = calculator.Calculate(tokens);
                            Console.WriteLine(result);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                }
            } while (!input.ToLower().Equals("q"));
        }
    }
}
