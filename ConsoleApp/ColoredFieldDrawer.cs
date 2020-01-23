using ConwaysGameOfLife;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class ColoredFieldDrawer : FieldDrawer
    {
        public static ConsoleColor CellColor;
        public static ConsoleColor BorderColor;

        public ColoredFieldDrawer(Field Field) : base(Field) { }

        protected override void DrawChar(char ch, int x, int y)
        {
            if (ch == CellChar) Console.BackgroundColor = CellColor;
            if (ch == BorderChar) Console.BackgroundColor = BorderColor;
            ch = ' ';
            base.DrawChar(ch, x, y);
            Console.ResetColor();
        }
    }
}
