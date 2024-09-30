using ConsoleApp.Drawers;
using ConsoleApp.FieldFillers;
using ConsoleApp.Settings;
using ConwaysGameOfLife;
using System;

namespace ConsoleApp.Menus
{
    internal class GameStartMenu : IMenu
    {
        public void Show()
        {
            Console.Clear();
            Console.WriteLine("Начало игры");
            Console.WriteLine("1 - Установить поле");
            Console.WriteLine("2 - Случайное поле");
            Console.WriteLine("3 - Глайдер");
            Console.WriteLine("4 - Назад");

            var choice = Console.ReadKey().Key;
            if (choice == ConsoleKey.D4 ||
                choice == ConsoleKey.NumPad4 || 
                choice == ConsoleKey.Escape)
            {
                return;
            }

            var field = new Field(GetFieldLength());
            var drawer = GetFieldDrawer(field);

            IFieldFiller fieldFiller = null;
            switch (choice)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1: fieldFiller = new CustomFieldFiller(drawer); break;

                case ConsoleKey.NumPad2:
                case ConsoleKey.D2: fieldFiller = new RandomFieldFiller(); break;

                case ConsoleKey.NumPad3:
                case ConsoleKey.D3: fieldFiller = new GlyderFieldFiller(); break;

                default: ShowError("Выберите корректный пункт меню!"); break;
            }

            var gameSession = new GameSession(fieldFiller, field, drawer);
            gameSession.Start();
        }

        public void ShowError(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Console.ReadKey();
        }

        private int GetFieldLength()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Введите длину поля");
                    var length = Console.ReadLine();
                    return int.Parse(length);
                }
                catch
                {
                    ShowError("Неккоректная длинна поля!");
                }
            }
        }

        private FieldDrawer GetFieldDrawer(Field field)
        {
            switch (MainSettings.Instance.ScreenMode) 
            {
                case ScreenModeEnum.Color: return new ColoredFieldDrawer(field);
                case ScreenModeEnum.Symbolic: return new FieldDrawer(field);
                default: return null;
            }
        }
    }
}
