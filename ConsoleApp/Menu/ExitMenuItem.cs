using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Menu
{
    class ExitMenuItem : BaseMenuItem
    {
        public ExitMenuItem(string id) : base(id) => Text = "выход";

        public override void Operation()
        {
            Environment.Exit(0);
        }
    }
}
