using GameOfLife;
using GameOfLife.Archive;
using System.Collections.Generic;

namespace ConwaysGameOfLife
{
    /// <summary>
    /// Класс игры
    /// </summary>
    public class Game
    {
        public GameState State { get; private set; }

        /// <summary>
        /// Игровое поле
        /// </summary>
        public Field Field { get; private set; }

        /// <summary>
        /// Количество сгенерированных поколений
        /// </summary>
        public int CurrentGeneration {  get; private set; }

        private readonly FieldArchive archive;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="field">Поле, на котором будет происходить игра</param>
        public Game(Field field)
        {
            this.Field = field;
            CurrentGeneration = 0;
            archive = new FieldArchive();
            State = new GameState();
        }

        /// <summary>
        /// Сгенерировать следующее поколение клеток
        /// </summary>
        /// <returns>Возвращает новое сгенерированное поле</returns>
        public Field NextGeneration()
        {
            GenerateGeneration();
            var isFieldAlive = Field.AliveCells != 0;
            var fieldRepeat = archive.Contains(Field);

            if (isFieldAlive && !fieldRepeat)
            {
                archive.Add(Field);
            }
            else
            {
                State.EndGame(isFieldAlive ? GameStatus.Infinity : GameStatus.Dead);
            }

            return Field;
        }

        /// <summary>
        /// Генерирует новое состояние клеток исходя из их расположения
        /// </summary>
        private void GenerateGeneration()
        {
            var willDie = new List<Cell>();
            var willAlive = new List<Cell>();
            foreach (Cell cell in Field)
            {
                if (cell.IsAlive)
                {
                    if (cell.NearestAlives != 2 && cell.NearestAlives != 3)
                        willDie.Add(cell);
                }
                else
                {
                    if (cell.NearestAlives == 3)
                        willAlive.Add(cell);
                }
            }
            foreach (var cell in willAlive)
                cell.IsAlive = true;
            foreach (var cell in willDie)
                cell.IsAlive = false;
            CurrentGeneration++;
        }
    }
}
