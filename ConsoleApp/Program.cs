using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ConwaysGameOfLife;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Игра \"Жизнь\" Джона Конвея");
                Console.WriteLine("Меню:");
                Console.WriteLine("1 - установить игровое поле");
                Console.WriteLine("2 - случайно сгенерированное поле");
                Console.WriteLine("3 - выход");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": StartCustomGame(); break;
                    case "2": StartRandomGame(); break;
                    case "3": Environment.Exit(0); break;
                    default: ShowError("Выберите корректный пункт меню!"); break;
                }
            }
        }

        static void StartGame(Field field, FieldDrawer drawer)
        {
            var cancelTknSrc = new CancellationTokenSource();
            var cancelToken = cancelTknSrc.Token;

            var task = new Task(() =>
            {
                Console.Clear();
                drawer.DrawFieldBorders();
                drawer.DrawField();
                var game = new Game(field);
                while (!game.Played)
                {
                    game.NextGeneration();
                    drawer.DrawField();
                    Thread.Sleep(100);

                    if (cancelToken.IsCancellationRequested)
                    {
                        Console.Clear();
                        return;
                    }
                }

                Console.WriteLine();
                Console.WriteLine($"Количество прожитых поколений - {game.Generations}");
            }, cancelToken);

            task.Start();
            Console.ReadKey();
            cancelTknSrc.Cancel();
            task.Wait();
        }

        static void StartCustomGame()
        {
            var field = new Field(GetFieldLength());
            var drawer = GetFieldDrawer(field);
            SetField(field, drawer);
            StartGame(field, drawer);
        }

        static void StartRandomGame()
        {
            var field = new Field(GetFieldLength());
            var drawer = GetFieldDrawer(field);

            var rnd = new Random();
            for (int i = 0; i < field.Length; i++)
                for (int j = 0; j < field.Length; j++)
                    field[i, j].Alive = rnd.Next(0, 2) == 0 ? false : true;

            StartGame(field, drawer);
        }

        static void SetField(Field field, FieldDrawer drawer)
        {
            drawer.DrawFieldBorders();
            var cursor = drawer.Cursor;

            while (true)
            {
                drawer.DrawCursor();
                var keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Enter)
                    break;
                if(keyInfo.Key == ConsoleKey.Spacebar)
                {
                    var shift = drawer.FieldStartPosition;
                    var cell = field[cursor.X - shift, cursor.Y - shift];
                    cell.Alive = cell.Alive ? false : true;
                    continue;
                }

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow: cursor.MoveUp(); break;
                    case ConsoleKey.DownArrow: cursor.MoveDown(); break;
                    case ConsoleKey.LeftArrow: cursor.MoveLeft(); break;
                    case ConsoleKey.RightArrow: cursor.MoveRight(); ; break;
                }
                drawer.DrawField();
            }
        }

        static int GetFieldLength()
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
                    ShowError("Неккоректная длин поля!");
                }
            }
        }

        static FieldDrawer GetFieldDrawer(Field field)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Использовать цветное поле? y - да, n - нет");
                var isColored = Console.ReadLine();
                if (isColored == "Y" || isColored == "y")
                    return new ColoredFieldDrawer(field, ConsoleColor.Green);
                else if (isColored == "N" || isColored == "n")
                    return new FieldDrawer(field);
            }
        }


        static void ShowError(string errorMessage)
        {
            Console.Clear();
            Console.WriteLine(errorMessage);
            Console.ReadKey();
        }



        /*static void DrawChar(char ch, int x, int y) => Map[x, y] = ch;

        

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
