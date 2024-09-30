using ConsoleApp.Settings;
using ConwaysGameOfLife;
using System;

namespace ConsoleApp.Drawers
{
    class FieldDrawer
    {
        protected static int shift;
        protected static char cellChar = '*';
        protected static char borderChar = '#';
        protected static ConsoleColor CursorColor = ConsoleColor.Gray;

        protected Field field;
        public Cursor Cursor;

        public FieldDrawer(Field Field)
        {
            var settings = MainSettings.Instance;
            shift = settings.FieldShift;
            cellChar = settings.SymbolicFieldSettings.CellChar;
            borderChar = settings.SymbolicFieldSettings.BorderChar;


            field = Field;
            Cursor = new Cursor(shift, shift, shift, shift + field.Length - 1);
            Cursor.Color = CursorColor;
        }

        public void DrawFieldBorders()
        {
            Console.Clear();
            var length = field.Length + shift;
            for (int i = 0; i < field.Length + 2; i++)
            {
                DrawChar(borderChar, i + shift - 1, shift - 1);
                DrawChar(borderChar, i + shift - 1, length);
            }
            for (int i = 0; i < field.Length; i++)
            {
                DrawChar(borderChar, shift - 1, i + shift);
                DrawChar(borderChar, length, i + shift);
            }
        }

        public void DrawField()
        {
            foreach (Cell cell in field)
                DrawChar(cell.IsAlive ? cellChar : ' ', cell.X + shift, cell.Y + shift);
        }

        protected virtual void DrawChar(char ch, int x, int y)
        {
            var length = field.Length + shift;
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
