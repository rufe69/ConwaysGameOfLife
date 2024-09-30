using System;

namespace ConsoleApp.Drawers
{
    class Cursor
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public static ConsoleColor Color = ConsoleColor.Gray;

        private int min;
        private int max;

        public Cursor(int x, int y, int minPosition, int maxPosition)
        {
            X = x;
            Y = y;
            min = minPosition;
            max = maxPosition;
        }

        public void MoveLeft() { if (X != min) X--; }
        public void MoveRight() { if (X != max) X++; }
        public void MoveUp() { if (Y != min) Y--; }
        public void MoveDown() { if (Y != max) Y++; }
    }
}
