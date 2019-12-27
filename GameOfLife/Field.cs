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
        /// <summary> Перечисление статусов поля</summary>
        public enum FieldStatus
        {
            Infinity,
            Dead,
            NotSet
        }

        /// <summary> Статус игрового поля</summary>
        public FieldStatus Status { get; private set; }

        /// <summary> Количество сгенерированных поколений</summary>
        public int Generation { get; private set; }

        /// <summary> Все клетки игрового поля</summary>
        List<Cell> Cells;

        /// <summary> Количество живых клеток на поле</summary>
        public int AliveCells => Cells.Count(x => x.Alive);

        /// <summary> Длина стороны игрового поля</summary>
        public int Length { get; }

        /// <summary> Конструктор</summary>
        /// <param name="Length">Длина стороны игрового поля</param>
        public Field(int Length)
        {
            Cells = new List<Cell>();
            this.Length = Length;
            SetStartField();
            Generation = 0;
            Status = FieldStatus.NotSet;
        }

        /// <summary> Устанавливает изначальное игровое поле</summary>
        private void SetStartField()
        {
            //Выставляет все клетки в игровое поле
            for (int i = 0; i < Length; i++)
                for (int j = 0; j < Length; j++)
                    Cells.Add(new Cell(i, j));

            //"Знакомит" каждую ячейку с её соседями
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

        /// <summary> Генерирует новое состояние клеток исходя из их расположения</summary>
        public void GenerateGeneration()
        {
            var WillDie = new List<Cell>();
            var WillAlive = new List<Cell>();
            foreach (var cell in Cells)
            {
                if (cell.Alive)
                {
                    if (cell.NearestAlives != 2 && cell.NearestAlives != 3)
                        WillDie.Add(cell);
                }
                else
                {
                    if (cell.NearestAlives == 3)
                        WillAlive.Add(cell);
                }
            }
            foreach (var cell in WillAlive) 
                cell.Alive = true;
            foreach (var cell in WillDie) 
                cell.Alive = false;
            Generation++;
        }

        /// <summary> Устанавливает статус игрового поля</summary>
        /// <param name="status"> Статус игрового поля</param>
        public void SetFieldStatus(FieldStatus status) => Status = status;

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
