using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week02
{
    internal class Menu
    {
        private readonly string title;
        public Menu(string title) => this.title = title;

        public void ShowMenu()
        {
            Console.WriteLine(title);
        }
    }
}
