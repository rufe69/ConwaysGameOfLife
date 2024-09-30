using ConwaysGameOfLife;

namespace ConsoleApp.FieldFillers
{
    /// <summary>
    /// Интферфейс для заполнения поля
    /// </summary>
    internal interface IFieldFiller
    {
        /// <summary>
        /// Заполнить поле
        /// </summary>
        void Fill(Field field);
    }
}
