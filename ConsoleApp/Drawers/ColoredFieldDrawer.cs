using ConsoleApp.Settings;
using ConwaysGameOfLife;
using System;

namespace ConsoleApp.Drawers
{
    class ColoredFieldDrawer : FieldDrawer
    {
        private static ConsoleColor cellColor;
        private static ConsoleColor borderColor;

        public ColoredFieldDrawer(Field Field) : base(Field)
        {
            cellColor = MainSettings.Instance.ColoredFieldSettings.CellColor;
            borderColor = MainSettings.Instance.ColoredFieldSettings.BorderColor;
        }

        protected override void DrawChar(char ch, int x, int y)
        {
            if (ch == cellChar) Console.BackgroundColor = cellColor;
            if (ch == borderChar) Console.BackgroundColor = borderColor;
            ch = ' ';
            base.DrawChar(ch, x, y);
            Console.ResetColor();
        }
    }
}
