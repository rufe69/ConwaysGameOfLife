using System;
using System.Collections.Generic;
using System.Text;

namespace ConwaysGameOfLife
{
    /// <summary> Класс игры</summary>
    public class Game
    {
        /// <summary> Поле, на котором происходит игра</summary>
        public Field Field { get; }

        public int Generations => Field.Generation;

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
        }

        /// <summary> Сгенерировать следующее поколение клеток</summary>
        /// <returns> Возвращает новое сгенерированное поле</returns>
        public Field NextGeneration()
        {
            Field.GenerateGeneration();
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
                    Field.SetFieldStatus(Field.FieldStatus.Dead);
                else if (fieldRepeat)
                    Field.SetFieldStatus(Field.FieldStatus.Infinity);
            }

            return Field;
        }
    }
}
