﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class Cursor
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public ConsoleColor Color { get; }

        private int min;
        private int max;

        public Cursor(int x, int y, int minPosition, int maxPosition)
        {
            X = x;
            Y = y;
            this.min = minPosition;
            this.max = maxPosition;
            Color = ConsoleColor.Gray;
        }

        public void MoveLeft() { if (X!=min) X--; }
        public void MoveRight() { if (X!=max) X++; }
        public void MoveUp() { if (Y!=min) Y--; }
        public void MoveDown() { if (Y!=max) Y++; }
    }
}
