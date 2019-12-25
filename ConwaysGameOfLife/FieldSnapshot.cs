using System;
using System.Collections.Generic;
using System.Text;

namespace ConwaysGameOfLife
{
    /// <summary> Класс, хранящий состояние конкретного объекта </summary>
    /// <remarks> По сути реализация паттерна Memento</remarks>
    class FieldSnapshot
    {
        bool[,] cells;
        int length;

        public FieldSnapshot(Field field)
        {
            length = field.Length;
            cells = new bool[length, length];
            for (int i = 0; i < length; i++)
                for (int j = 0; j < length; j++)
                    cells[i, j] = field[i, j].Alive;
        }

        public bool Compare(Field field)
        {
            for (int i = 0; i < length; i++)
                for (int j = 0; j < length; j++)
                    if (cells[i, j] != field[i, j].Alive)
                        return false;
            return true;
        }
    }
}
