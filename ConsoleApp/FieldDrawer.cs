using ConwaysGameOfLife;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class FieldDrawer
    {

        protected Field field;
        protected readonly int shift;
        protected char pointSymbol = '*';

        public int FieldLength => field.Length;
        public int FieldStartPosition => shift;

        public FieldDrawer(Field Field)
        {
            field = Field;
            shift = 1;
        }

        public void DrawFieldBorders()
        {
            Console.Clear();
            var length = field.Length + shift;
            for (int i = 0; i < length + 1; i++)
            {
                DrawChar('#', i, 0);
                DrawChar('#', i, length);
            }
            for (int i = 0; i < length; i++)
            {
                DrawChar('#', 0, i);
                DrawChar('#', length, i);
            }
        }

        public void DrawField()
        {
            foreach (Cell cell in field)
                DrawChar(cell.Alive ? pointSymbol : ' ', cell.X + shift, cell.Y + shift);
        }

        protected virtual void DrawChar(char ch, int x, int y)
        {
            var length = field.Length + shift;
            Console.SetCursorPosition(x, y);
            Console.Write(ch);
            Console.SetCursorPosition(length + 1, length + 1);
        }

        public virtual void DrawPoint(int x, int y)
        {
            var cell = field[x - shift, y - shift];
            DrawChar(cell.Alive ? pointSymbol : ' ', x, y);
            Console.SetCursorPosition(x, y);
        }

        public virtual void DrawCursor(int x, int y)
        {

        }
    }
}
