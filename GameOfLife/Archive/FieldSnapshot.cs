using ConwaysGameOfLife;

namespace GameOfLife.Archive
{
    //Memento
    /// <summary>
    /// Класс, хранящий состояние ячеек игрового поля
    /// </summary>
    class FieldSnapshot
    {
        private readonly bool[,] cells;
        private readonly int length;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="field">Поле, снимок которого будет хранить класс</param>
        public FieldSnapshot(Field field)
        {
            length = field.Length;
            cells = new bool[length, length];
            for (int i = 0; i < length; i++)
                for (int j = 0; j < length; j++)
                    cells[i, j] = field[i, j].IsAlive;
        }

        /// <summary>
        /// Сравнение игрового поля со снимком
        /// </summary>
        /// <param name="field">Сравниваемое игровое поле</param>
        public bool Compare(Field field)
        {
            for (int i = 0; i < length; i++)
                for (int j = 0; j < length; j++)
                    if (cells[i, j] != field[i, j].IsAlive)
                        return false;
            return true;
        }
    }
}
