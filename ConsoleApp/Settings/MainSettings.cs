using ConsoleApp.Drawers;

namespace ConsoleApp.Settings
{
    //Singleton
    /// <summary>
    /// Класс настроек
    /// </summary>
    internal class MainSettings
    {
        private static MainSettings instance = new();

        public static MainSettings Instance => instance;

        /// <summary>
        /// Режим отображения поля
        /// </summary>
        public ScreenModeEnum ScreenMode { get; set; } = ScreenModeEnum.Color;

        /// <summary>
        /// Настройка цветов при цветном отображении поля
        /// </summary>
        public ColoredFieldSettings ColoredFieldSettings { get; set; } = new();

        /// <summary>
        /// Настройка символов при символьном отображении поля
        /// </summary>
        public SymbolicFieldSettings SymbolicFieldSettings { get; set; } = new();

        /// <summary>
        /// Сдвиг поля для корректного отображения границ
        /// </summary>
        public int FieldShift { get; } = 1;

        /// <summary>
        /// Скорость игры (Чем меньше speed, тем быстрее игра)
        /// </summary>
        public int Speed { get; set; } = 100;
    }
}
