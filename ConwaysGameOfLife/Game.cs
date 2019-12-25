using System;
using System.Collections.Generic;
using System.Text;

namespace ConwaysGameOfLife
{
    /// <summary> Класс игры</summary>
    class Game
    {
        Field field;
        FieldArchive archive;
        public bool Played { get; private set; }
        public int Generations { get; private set; }
        public Field.FieldStatus FieldStatus => field.Status;

        public Game(Field Field)
        {
            field = Field;
            archive = new FieldArchive();
            Played = false;
            Generations = 0;
        }

        public string Start()
        {
            try
            {
                if (Played)
                    return "Данная игра уже сыграна! Начните новую игру!";

                
                while (field.AliveCells != 0 || !archive.Contains(field))
                {
                    field.SetCellsStates();
                    archive.Add(field);
                    Generations++;
                }

                Played = true;

                if (field.AliveCells == 0)
                    field.SetFieldStatus(Field.FieldStatus.Dead);
                else if (archive.Contains(field))
                    field.SetFieldStatus(Field.FieldStatus.Infinity);

                return "Error";
            }
            catch(Exception err)
            {
                return $"Ошибка игры! Сообщение: {err.Message}";
            }
        }
    }
}
