using System;
using System.Collections.Generic;
using System.Text;

namespace ConwaysGameOfLife
{
    /// <summary> Класс, хранящий состояние ячеек конкретного объекта класса Field </summary>
    /// <remarks> По сути реализация паттерна Memento (хранитель), только без восстановления поля</remarks>
    class FieldSnapshot
    {
        bool[,] cells;
        int length;

        /// <summary> Конструктор</summary>
        /// <param name="field"> Поле, снимок которого будет хранить класс</param>
        public FieldSnapshot(Field field)
        {
            length = field.Length;
            cells = new bool[length, length];
            for (int i = 0; i < length; i++)
                for (int j = 0; j < length; j++)
                    cells[i, j] = field[i, j].Alive;
        }

        /// <summary> Сравнение игрового поля со снимком</summary>
        /// <param name="field">Сравниваемое игровое поле</param>
        /// <returns> Возвращает true, если данный снимок является снимком передаваемого Field, иначе false</returns>
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
