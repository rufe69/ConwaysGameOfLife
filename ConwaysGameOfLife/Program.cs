using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ConwaysGameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Игра \"Жизнь\" Джона Конвея");
                Console.WriteLine("Меню:");
                Console.WriteLine("1 - установить игровое поле");
                Console.WriteLine("2 - случайно сгенерированное поле");
                Console.WriteLine("3 - правила игры");
                Console.WriteLine("4 - выход");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": StartCustomGame(); break;
                    case "2": StartRandomGame(); break;
                    case "3": ShowRules(); break;
                    case "4": Environment.Exit(0); break;
                    default: MenuError(); break;
                }
            }
        }

        static void StartGame(Field field)
        {
            var game = new Game(field);
            DrawFieldTemp(field);
            while (!game.Played)
            {
                DrawFieldTemp(game.NextGeneration());
                Thread.Sleep(100);
            }
        }

        static void DrawFieldTemp(Field field)
        {
            Console.WriteLine();
            for (int i = 0; i < field.Length; i++)
            {
                for (int j = 0; j < field.Length; j++)
                {
                    Console.Write(field[i, j].Alive ? "1" : " ");
                }
                Console.WriteLine();
            }
        }

        static void ShowRules()
        {
            Console.Clear();
            Console.WriteLine("Правила");
            ExitToMain();
        }

        static void MenuError()
        {
            Console.Clear();
            Console.WriteLine("Выберите корректный пункт меню!");
            ExitToMain();
        }

        static void ExitToMain()
        {
            Console.WriteLine();
            Console.WriteLine("Нажмите любую кнопку, чтобы вернуться в главное меню");
            Console.ReadKey();
        }

        static void StartCustomGame()
        {
            Console.Clear();
            var field = new Field(10);
            field[0, 2].Alive = true;
            field[1, 0].Alive = true;
            field[1, 2].Alive = true;
            field[2, 1].Alive = true;
            field[2, 2].Alive = true;
            StartGame(field);
            ExitToMain();
        }

        static void StartRandomGame()
        {
            Console.Clear();
            Console.WriteLine("Введите длину поля");
            var length = Console.ReadLine();
            var field = new Field(int.Parse(length));

            var rnd = new Random();
            for (int i = 0; i < field.Length; i++)
                for (int j = 0; j < field.Length; j++)
                    field[i, j].Alive = rnd.Next(0, 2) == 0 ? false : true;

            StartGame(field);
            ExitToMain();
        }



        /*static void DrawChar(char ch, int x, int y) => Map[x, y] = ch;

        static void CursorMoving(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow: if (y != 2) y-- ; break;
                case ConsoleKey.DownArrow: if (y != height) y++ ; break;
                case ConsoleKey.LeftArrow: if (x != 2) x-- ; break;
                case ConsoleKey.RightArrow: if (x != width) x++ ; break;
            }
        }

        static void SetGame()
        {
            while (true)
            {
                Console.SetCursorPosition(x, y);
                var keyinfo = Console.ReadKey();
                if (keyinfo.Key == ConsoleKey.Escape) break;
                if (keyinfo.Key == ConsoleKey.Spacebar)
                {
                    DrawChar('*', x, y);
                    continue;
                }

                CursorMoving(keyinfo);
                RefreshMap();
            }
        }

        static void DrawField(int width, int height)
        {
            for (int i = 0; i < width; i++)
            {
                DrawChar('#', i, 0);
                DrawChar('#', i, height - 1);
            }
            for (int i = 0; i < height; i++)
            {
                DrawChar('#', 0, i);
                DrawChar('#', width - 1, i);
            }

            Console.SetCursorPosition(1, 1);
        }

        static void RefreshMap()
        {
            Console.Clear();
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(Map[i, j]);
                }
            }
        }*/
    }

   
    
}
