using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ConwaysGameOfLife
{
    class Program
    {
        static int length = 100;


        static void Main(string[] args)
        {
            /*DrawField(width, height);
            RefreshMap();
            SetGame();*/
            var Field = new Field(20);

        }

        

        

        

        /*static void DrawChar(char ch, int x, int y) => Map[x, y] = ch;

        static void CursorMoving(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow: if (y != 2) y-- ; break;
                case ConsoleKey.DownArrow: if (y != height) y++ ; break;
                case ConsoleKey.LeftArrow: if (x != 2) x-- ; break;
                case ConsoleKey.RightArrow: if (x != width) x++ ; break;
            }
        }

        static void SetGame()
        {
            while (true)
            {
                Console.SetCursorPosition(x, y);
                var keyinfo = Console.ReadKey();
                if (keyinfo.Key == ConsoleKey.Escape) break;
                if (keyinfo.Key == ConsoleKey.Spacebar)
                {
                    DrawChar('*', x, y);
                    continue;
                }

                CursorMoving(keyinfo);
                RefreshMap();
            }
        }

        static void DrawField(int width, int height)
        {
            for (int i = 0; i < width; i++)
            {
                DrawChar('#', i, 0);
                DrawChar('#', i, height - 1);
            }
            for (int i = 0; i < height; i++)
            {
                DrawChar('#', 0, i);
                DrawChar('#', width - 1, i);
            }

            Console.SetCursorPosition(1, 1);
        }

        static void RefreshMap()
        {
            Console.Clear();
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(Map[i, j]);
                }
            }
        }*/
    }

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

        /// <summary> Удаляет клетку из близжайших</summary>
        /// <param name="cell"> Удаляемая клетка</param>
        public void RemoveNearest(Cell cell) => NearestCells.Remove(cell);

        /// <summary> Конструктор класса</summary>
        /// <param name="x"> Координата x на игровом поле</param>
        /// <param name="y"> Координата y на игровом поле</param>
        public Cell(int x, int y)
        {
            X = x;
            Y = y;
            NearestCells = new List<Cell>();
        }
    }

    /// <summary> Класс, отвечающий за игровое поле</summary>
    public class Field
    {
        /// <summary> Все клетки игрового поля</summary>
        List<Cell> Cells;

        /// <summary> Длина стороны игрового поля</summary>
        public int Length { get; }

        /// <summary> Конструктор</summary>
        /// <param name="Length">Длина стороны игрового поля</param>
        public Field(int Length)
        {
            Cells = new List<Cell>();
            this.Length = Length;
            SetStartField();
        }

        /// <summary> Устанавливает изначальное игровое поле</summary>
        private void SetStartField()
        {
            //Выставляет все клетки в игровое поле
            for (int i = 0; i < Length; i++)
                for (int j = 0; j < Length; j++)
                    Cells.Add(new Cell(i, j));



            //"Знакомит" все клетки с их соседями
            for (int i = 0; i < Length; i++)
                for (int j = 0; j < Length; j++)
                {
                    var currCell = Cells.Where(elem =>
                    {
                        var modX = j % Length;
                        var modY = i % Length;
                        return (elem.X == modX - 1 && elem.Y == modY - 1) || elem.X == modX - 1;

                    });
                }
        }

        /// <summary> Устанавливает состояния ячеек после каждого раунда</summary>
        public void SetCellsStates()
        {
            foreach (var cell in Cells)
            {
                if (cell.Alive)
                {
                    if (cell.NearestAlives != 2 || cell.NearestAlives != 3)
                        cell.Alive = false;
                }
                else
                {
                    if (cell.NearestAlives == 3)
                        cell.Alive = true;
                }
            }
        }

        /// <summary>
        /// Возвращает ячейку с координатами x и y. Работает зациклено.
        /// Eсли длина массива = 10, а мы передадим x=11 и y=11, то вернет ячейку x=1 и y=1
        /// </summary>
        /// <param name="x"> Координата x</param>
        /// <param name="y"> Координата y</param>
        /// <returns> Возвращает клетку в игровом поле с координатами x и y</returns>
        private Cell this[int x, int y] => Cells.FirstOrDefault(elem=> elem.X == x%Length && elem.Y == y%Length);
    }
}
