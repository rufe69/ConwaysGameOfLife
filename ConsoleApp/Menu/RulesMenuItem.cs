using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Menu
{
    class RulesMenuItem : BaseMenuItem
    {
        public RulesMenuItem(string id) : base(id) => Text = "правила игры";

        public override void Operation()
        {
            Console.Clear();
            Console.WriteLine("Правила");
        }
    }
}
