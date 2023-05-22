using System.Reflection.PortableExecutable;

namespace Week03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRPNCalculator calculator = new RPNCalculator();
            calculator.Add(new Addition());
            calculator.Add(new Subtraction());
            calculator.Add(new Multiplication());
            calculator.Add(new Division());
            calculator.Add(new Exponentation());
            calculator.Add(new Sqrt());
            calculator.Add(new NaturalExponential());
            calculator.Add(new NaturalLogarithm());
            calculator.Add(new Constant("pi", "Constant pi", Math.PI));
            calculator.Add(new Constant("e", "Constant e, also known as Euler's number.", Math.E));

            IParser parser = new Parser(calculator.Operators);
            IMenu menu = new Menu(calculator.Operations);
            Controller controller = new Controller(calculator, parser, menu);
            controller.Run();
        }
    }
}