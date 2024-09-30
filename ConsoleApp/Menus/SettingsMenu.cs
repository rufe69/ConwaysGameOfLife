using ConsoleApp.Drawers;
using ConsoleApp.Settings;
using System;

namespace ConsoleApp.Menus
{
    internal class SettingsMenu : IMenu
    {
        public void Show()
        {
            while (true)
            {
                var settings = MainSettings.Instance;

                Console.Clear();
                Console.WriteLine("Настройки");
                if (settings.ScreenMode == ScreenModeEnum.Symbolic)
                {
                    Console.WriteLine("1 - Выбрать визуальный режим игры (сейчас символьный)");
                    Console.WriteLine("2 - Настройка символов");
                }
                else
                {
                    Console.WriteLine("1 - Выбрать визуальный режим игры (сейчас цветной)");
                    Console.WriteLine("2 - Настройка цветов");
                }
                Console.WriteLine("3 - Скорость игры");
                Console.WriteLine("4 - Назад");

                var choice = Console.ReadKey().Key;
                if (choice == ConsoleKey.D4 ||
                    choice == ConsoleKey.NumPad4 ||
                    choice == ConsoleKey.Escape)
                {
                    return;
                }

                switch (choice)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1: SetGameMode(); break;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2: SetSymbols(); break;

                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3: SetSpeed(); break;

                    default: ShowError("Выберите корректный пункт меню!"); break;
                }
            }
        }

        private void SetGameMode()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите визуальный режим игры");
                Console.WriteLine("1 - Цветной");
                Console.WriteLine("2 - Символьный");

                var choice = Console.ReadKey().Key;

                switch (choice)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1: MainSettings.Instance.ScreenMode = ScreenModeEnum.Color; return;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2: MainSettings.Instance.ScreenMode = ScreenModeEnum.Symbolic; return;

                    case ConsoleKey.Escape: return;
                }
            }
        }

        private void SetSymbols()
        {

        }

        private void SetSpeed()
        {

        }

        public void ShowError(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}
