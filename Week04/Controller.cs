using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Week04
{
    internal class Controller
    {
        public IMenu Menu { get; set; }
        private List<IExpressionEvaluator<double>> Evaluators { get; } = new();

        private IExpressionEvaluator<double> currentEvaluator;
        private IExpressionEvaluator<double> CurrentEvaluator
        {
            get { return currentEvaluator; }
            set
            {
                if (Menu is not null)
                {
                    Menu.Help = value?.Help;
                }

                currentEvaluator = value;
            }
        }


        private readonly ICalculator calculator;
        private readonly IParser parser;
        private readonly IMenu menu;

        public Controller(IExpressionEvaluator<double>[] evaluators, IMenu menu)
        {
            Evaluators.AddRange(evaluators);
            Menu = menu;
            CurrentEvaluator = Evaluators.First();
        }

        public void Run()
        {
            menu.ShowMenu();
            string input;

            do
            {
                Console.Write("> ");
                input = Console.ReadLine() ?? "q";
                switch (input)
                {
                    case "q":
                        break;
                    case "s":
                        
                    case "h":
                        menu.ShowHelp();
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
                            WriteError(e.Message);
                        }
                        break;
                }
            } while (!input.ToLower().Equals("q"));

        }

        private void SwitchEvalutator()
        {
            for (int idx = 0; idx < Evaluators.Count; idx++) 
            {
                Console.WriteLine($"{idx}. {Evaluators[idx].Description}");
            }

            Console.WriteLine("Choose an option: ");
            int option;
            while (!int.TryParse(Console.ReadLine(), out option) || !IsInRange(option, 0, Evaluators.Count))
            {
                WriteError("Invalid input. Please try again.");
                Console.WriteLine("Choose an option: ");
            }

            CurrentEvaluator = Evaluators[option];

            static bool IsInRange(int value, int low, int high) => value >= low && value < high;
        }

        private void WriteError(string message) => WriteMessage(message, ConsoleColor.Red);

        private void WriteMessage(string message, ConsoleColor color)
        {
            (color, Console.ForegroundColor) = (Console.ForegroundColor, color);
            Console.WriteLine(message);
            Console.ForegroundColor = color;
        }
    }
}
