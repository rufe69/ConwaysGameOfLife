﻿using ConwaysGameOfLife;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class ColoredFieldDrawer : FieldDrawer
    {
        private ConsoleColor _color;

        public ColoredFieldDrawer(Field Field, ConsoleColor color) : base(Field) => _color = color;

        protected override void DrawChar(char ch, int x, int y)
        {
            if (ch == '*') Console.BackgroundColor = _color;
            if (ch == '#') Console.BackgroundColor = ConsoleColor.Red;
            ch = ' ';
            base.DrawChar(ch, x, y);
            Console.ResetColor();
        }
    }
}
