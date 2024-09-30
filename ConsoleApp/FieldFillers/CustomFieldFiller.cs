using ConsoleApp.Drawers;
using ConsoleApp.Settings;
using ConwaysGameOfLife;
using System;

namespace ConsoleApp.FieldFillers
{
    /// <summary>
    /// Режим ручного заполнения поля
    /// </summary>
    internal class CustomFieldFiller : IFieldFiller
    {
        private readonly FieldDrawer fieldDrawer;
        private int fieldShift { get; }

        public CustomFieldFiller(FieldDrawer fieldDrawer)
        {
            this.fieldDrawer = fieldDrawer;
            fieldShift = MainSettings.Instance.FieldShift;
        }

        /// <inheritdoc/>
        public void Fill(Field field)
        {
            fieldDrawer.DrawFieldBorders();
            var cursor = fieldDrawer.Cursor;

            while (true)
            {
                fieldDrawer.DrawCursor();
                var keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Enter)
                    break;
                if (keyInfo.Key == ConsoleKey.Spacebar)
                {
                    var cell = field[cursor.X - fieldShift, cursor.Y - fieldShift];
                    cell.IsAlive = cell.IsAlive ? false : true;
                }

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow: cursor.MoveUp(); break;
                    case ConsoleKey.DownArrow: cursor.MoveDown(); break;
                    case ConsoleKey.LeftArrow: cursor.MoveLeft(); break;
                    case ConsoleKey.RightArrow: cursor.MoveRight(); break;
                }
                fieldDrawer.DrawField();
            }
        }
    }
}
