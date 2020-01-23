using ConwaysGameOfLife;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class FieldDrawer
    {
        public static int Shift;
        public static char CellChar = '*';
        public static char BorderChar = '#';
        public static ConsoleColor CursorColor = ConsoleColor.Gray;

        protected Field field;
        public Cursor Cursor;

        public int FieldLength => field.Length;
        public int FieldStartPosition => Shift;

        public FieldDrawer(Field Field)
        {
            field = Field;
            Cursor = new Cursor(Shift, Shift, Shift, Shift + field.Length -1);
            Cursor.Color = CursorColor;
        }

        public void DrawFieldBorders()
        {
            Console.Clear();
            var length = field.Length + Shift;
            for (int i = 0; i < field.Length + 2; i++)
            {
                DrawChar(BorderChar, i + Shift -1, Shift - 1);
                DrawChar(BorderChar, i + Shift -1, length);
            }
            for (int i = 0; i < field.Length; i++)
            {
                DrawChar(BorderChar, Shift - 1, i + Shift);
                DrawChar(BorderChar, length, i + Shift);
            }
        }

        public void DrawField()
        {
            foreach (Cell cell in field)
                DrawChar(cell.Alive ? CellChar : ' ', cell.X + Shift, cell.Y + Shift);
        }

        protected virtual void DrawChar(char ch, int x, int y)
        {
            var length = field.Length + Shift;
            Console.SetCursorPosition(x, y);
            Console.Write(ch);
            Console.SetCursorPosition(length + 1, length + 1);
        }

        public virtual void DrawCursor()
        {
            Console.BackgroundColor = Cursor.Color;
            DrawChar(' ', Cursor.X, Cursor.Y);
            Console.ResetColor();
        }
    }
}
