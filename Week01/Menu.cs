using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week01
{
    internal class Menu
    {
        private List<(string name, Action handler)> items = new();
        private string title;
        private bool shouldClose = false;

        public void AddItem(string name, Action handler) => items.Add((name, handler));

        public Menu(string title) => this.title = title;

        public void Run()
        {
            while (!shouldClose)
            {
                Write();
                int itemIndex = ReadOption() - 1;
                Console.Clear();
                items[itemIndex].handler();
                Console.Clear();
            }
        }

        public void Close() => shouldClose = true;

        int ReadOption()
        {
            ConsoleKeyInfo keyInfo;
            int input;

            do
            {
                keyInfo = Console.ReadKey(true);
            }
            while (!int.TryParse(keyInfo.KeyChar.ToString(), out input) || !IsItem(input));

            return input;
        }

        private void Write()
        {
            Console.WriteLine(title);

            foreach (int number in Enumerable.Range(1, items.Count))
            {
                Console.WriteLine($"{number}. {items[number - 1].name}");
            }
        }

        private bool IsItem(int number) => number >= 1 && number <= items.Count;
    }
}
