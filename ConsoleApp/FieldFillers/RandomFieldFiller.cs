using ConwaysGameOfLife;
using System;

namespace ConsoleApp.FieldFillers
{
    /// <summary>
    /// Режим случайного заполнения поля
    /// </summary>
    internal class RandomFieldFiller : IFieldFiller
    {
        /// <inheritdoc/>
        public void Fill(Field field)
        {
            var rnd = new Random();
            for (int i = 0; i < field.Length; i++)
                for (int j = 0; j < field.Length; j++)
                    field[i, j].IsAlive = rnd.Next(0, 2) == 0 ? false : true;
        }
    }
}
