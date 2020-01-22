using ConwaysGameOfLife;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class FieldDrawer
    {

        private Field field;
        private int shift;

        public FieldDrawer(Field Field)
        {
            field = Field;
            shift = 1;
        }

        public static Field CreateField()
        {
            throw new Exception();
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
                DrawChar(cell.Alive ? '*' : ' ', cell.X + shift, cell.Y + shift);
        }

        protected virtual void DrawChar(char ch, int x, int y)
        {
            var length = field.Length + shift;
            Console.SetCursorPosition(x, y);
            Console.Write(ch);
            Console.SetCursorPosition(length + 1, length + 1);
        }
    }
}
