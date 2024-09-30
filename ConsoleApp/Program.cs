using ConsoleApp.Drawers;
using ConsoleApp.Menus;
using ConsoleApp.Settings;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            while (true)
            {
                var mainMenu = new MainMenu();
                mainMenu.Show();
            }
        }
    }
}
