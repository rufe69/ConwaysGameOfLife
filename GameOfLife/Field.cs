using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConwaysGameOfLife
{
    /// <summary> Класс, отвечающий за игровое поле</summary>
    public class Field:IEnumerable
    {
        /// <summary> Все клетки игрового поля</summary>
        List<Cell> Cells;

        /// <summary> Количество живых клеток на поле</summary>
        public int AliveCells => Cells.Count(x => x.Alive);

        /// <summary> Длина стороны игрового поля</summary>
        public int Length { get; }

        /// <summary> Конструктор</summary>
        /// <param name="Length"> Длина стороны игрового поля</param>
        public Field(int Length)
        {
            Cells = new List<Cell>();
            this.Length = Length;
            SetEmptyCells();
            SetCellsNeighbors();
        }

        /// <summary> Выставляет пустые клетки в игровое поле</summary>
        private void SetEmptyCells()
        {
            for (int i = 0; i < Length; i++)
                for (int j = 0; j < Length; j++)
                    Cells.Add(new Cell(i, j));
        }

        /// <summary> "Знакомит" каждую ячейку с её соседями</summary>
        private void SetCellsNeighbors()
        {
            //Мне лень было придумывать красивый алгоритм добавления
            foreach(var cell in Cells)
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

        /// <summary> Возвращяет итератор для циклов типа foreach</summary>
        public IEnumerator GetEnumerator() => Cells.GetEnumerator();

        /// <summary> Индексатор возвращающий ячейку с координатами x и y</summary>
        /// <remarks>
        /// <para> Поле тороидально зациклено</para>
        /// <para> 
        /// Это значит, что при обращении к ячейкам он будет по кругу ходить в одной 
        /// строке/столбце, а не вызовет OutOfRangeException
        /// </para>
        /// </remarks>
        /// <param name="x"> Координата x</param>
        /// <param name="y"> Координата y</param>
        /// <returns> Возвращает клетку в игровом поле с координатами x и y</returns>
        /// 
        public Cell this[int x, int y] => Cells.FirstOrDefault(elem => elem.X == Math.Abs((x + Length) % Length) &&
                                                                       elem.Y == Math.Abs((y + Length) % Length));
    }
}
