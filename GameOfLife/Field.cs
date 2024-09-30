using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife
{
    /// <summary>
    /// Игровое поле
    /// </summary>
    public class Field : IEnumerable
    {
        private readonly List<Cell> Cells;
        
        /// <summary>
        /// Длина стороны игрового поля
        /// </summary>
        public int Length { get; }

        /// <summary>
        /// Количество живых клеток на поле
        /// </summary>
        public int AliveCells => Cells.Count(x => x.IsAlive);

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Length">Длина стороны игрового поля</param>
        public Field(int Length)
        {
            Cells = new List<Cell>();
            this.Length = Length;
            FillField();
        }

        /// <summary>
        /// Заполняет поле мертвыми клетками
        /// </summary>
        private void FillField()
        {
            for (int i = 0; i < Length; i++)
                for (int j = 0; j < Length; j++)
                    Cells.Add(new Cell(i, j));

            //Создание связей между клетками
            foreach (var cell in Cells)
            {
                cell.AddNearest(this[cell.X - 1, cell.Y - 1]);
                cell.AddNearest(this[cell.X, cell.Y - 1]);
                cell.AddNearest(this[cell.X + 1, cell.Y - 1]);
                cell.AddNearest(this[cell.X - 1, cell.Y]);
                cell.AddNearest(this[cell.X + 1, cell.Y]);
                cell.AddNearest(this[cell.X - 1, cell.Y + 1]);
                cell.AddNearest(this[cell.X, cell.Y + 1]);
                cell.AddNearest(this[cell.X + 1, cell.Y + 1]);
            }
        }

        public IEnumerator GetEnumerator() => Cells.GetEnumerator();

        /// <summary>
        /// Индексатор возвращающий ячейку с координатами x и y
        /// </summary>
        /// <param name="x"> Координата x</param>
        /// <param name="y"> Координата y</param>
        /// <remarks>
        /// Поле тороидально зациклено.
        /// Это значит, что при обращении к ячейкам он будет по кругу ходить в одной 
        /// строке/столбце, а не вызовет OutOfRangeException
        /// </remarks>
        /// <returns> Возвращает клетку в игровом поле с координатами x и y</returns>
        public Cell this[int x, int y] => Cells.FirstOrDefault(elem => elem.X == Math.Abs((x + Length) % Length) &&
                                                                       elem.Y == Math.Abs((y + Length) % Length));
    }
}
