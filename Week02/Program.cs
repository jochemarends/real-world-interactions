namespace Week02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRPNCalculator calculator = new RPNCalculator();
            IParser parser = new Parser(calculator.Operators);
            IMenu menu = new Menu(calculator.OperationsHelpText);
            Controller controller = new Controller(calculator, parser, menu);
            controller.Run();
        }
    }
}