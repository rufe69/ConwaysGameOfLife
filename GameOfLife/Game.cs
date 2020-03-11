using GameOfLife;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConwaysGameOfLife
{
    /// <summary> Класс игры</summary>
    public class Game
    {
        /// <summary> Статус игрового поля</summary>
        public GameStatus Status { get; set; }

        /// <summary> Поле, на котором происходит игра</summary>
        public Field Field { get; }


        /// <summary> Количество сгенерированных поколений</summary>
        public int Generation { get; private set; }

        FieldArchive archive;

        /// <summary> Возвращает статус игры true - сыграна, false - не сыграна</summary>
        public bool Played { get; private set; }
        
        /// <summary> Конструктор</summary>
        /// <param name="Field"> Поле, на котором будет происходить игра</param>
        public Game(Field Field)
        {
            this.Field = Field;
            archive = new FieldArchive();
            Played = false;
            Generation = 0;
            Status = GameStatus.NotSet;
        }

        /// <summary> Сгенерировать следующее поколение клеток</summary>
        /// <returns> Возвращает новое сгенерированное поле</returns>
        public Field NextGeneration()
        {
            GenerateGeneration();
            var fieldIsAlive = Field.AliveCells != 0;
            var fieldRepeat = archive.Contains(Field);

            if (fieldIsAlive && !fieldRepeat)
            {
                archive.Add(Field);
            }
            else
            {
                Played = true;

                if (!fieldIsAlive)
                    Status = GameStatus.Dead;
                else if (fieldRepeat)
                    Status = GameStatus.Infinity;
            }

            return Field;
        }

        /// <summary> Генерирует новое состояние клеток исходя из их расположения</summary>
        private void GenerateGeneration()
        {
            var WillDie = new List<Cell>();
            var WillAlive = new List<Cell>();
            foreach (Cell cell in Field)
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
    }
}
