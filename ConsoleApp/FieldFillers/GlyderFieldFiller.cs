using ConwaysGameOfLife;

namespace ConsoleApp.FieldFillers
{
    /// <summary>
    /// Режим заполнение поля в виде планера
    /// </summary>
    internal class GlyderFieldFiller : IFieldFiller
    {
        /// <inheritdoc/>
        public void Fill(Field field)
        {
            field[0, 1].IsAlive = true;
            field[1, 2].IsAlive = true;
            field[2, 0].IsAlive = true;
            field[2, 1].IsAlive = true;
            field[2, 2].IsAlive = true;
        }
    }
}
