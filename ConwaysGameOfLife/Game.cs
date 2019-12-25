using System;
using System.Collections.Generic;
using System.Text;

namespace ConwaysGameOfLife
{
    /// <summary> Класс игры</summary>
    class Game
    {
        public Field Field { get; }

        FieldArchive archive;

        /// <summary> Возвращает статус игры true - сыграна, false - не сыграна</summary>
        public bool Played { get; private set; }

        public Game(Field Field)
        {
            this.Field = Field;
            archive = new FieldArchive();
            Played = false;
        }

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
