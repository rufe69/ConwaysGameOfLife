using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Menu
{
    class BaseMenuItem
    {
        public string Id { get; }
        public string Text { get; internal set; }

        public BaseMenuItem(string id)
        {
            Id = id;
            Text = "";
        }

        public virtual void Operation() { }
    }
}
