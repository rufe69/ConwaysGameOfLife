using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConwaysGameOfLife
{
    /// <summary> Игровая клетка</summary>
    public class Cell
    {
        /// <summary> Координата X</summary>
        public int X { get; private set; }
        /// <summary> Координата Y</summary>
        public int Y { get; private set; }

        /// <summary> Состояние клетки true - жива, false - мертва</summary>
        public bool Alive { get; set; }

        /// <summary> Близжайшие клетки</summary>
        private List<Cell> NearestCells;

        /// <summary> Показывает количество близжайших клеток</summary>
        public int NearestAlives => NearestCells.Count(x => x.Alive);

        /// <summary> Добавляет новую клетку в близжайшие</summary>
        /// <param name="cell"> Добавляемая клетка</param>
        public void AddNearest(Cell cell) => NearestCells.Add(cell);

        /// <summary> Конструктор</summary>
        /// <param name="x"> Координата x на игровом поле</param>
        /// <param name="y"> Координата y на игровом поле</param>
        public Cell(int x, int y)
        {
            X = x;
            Y = y;
            NearestCells = new List<Cell>();
            Alive = false;
        }
    }

}
