using System;

namespace ConsoleApp.Menus
{
    /// <summary>
    /// Главное меню программы
    /// </summary>
    internal class MainMenu : IMenu
    {
        /// <inheritdoc/>
        public void Show()
        {
            Console.Clear();
            Console.WriteLine("Игра \"Жизнь\" Джона Конвея");
            Console.WriteLine("1 - Начать");
            Console.WriteLine("2 - Настройки");
            Console.WriteLine("3 - Выход");

            var choice = Console.ReadKey().Key;
            IMenu menu = null;
            switch (choice)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1: menu = new GameStartMenu(); break;

                case ConsoleKey.NumPad2:
                case ConsoleKey.D2: menu = new SettingsMenu(); break;

                case ConsoleKey.Escape:
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3: Environment.Exit(0); break;

                default: ShowError("Выберите корректный пункт меню!"); break;
            }

            if (menu is not null)
            {
                menu.Show();
            }
        }

        public void ShowError(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}
