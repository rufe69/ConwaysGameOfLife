using ConwaysGameOfLife;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static ConsoleColor BorderColor = ConsoleColor.Red;
        static ConsoleColor CellColor = ConsoleColor.Green;
        static ConsoleColor CursorColor = ConsoleColor.Gray;
        static int FieldShift = 1;
        static char BorderChar = '#';
        static char CellChar = '*';

        //Чем меньше speed, тем быстрее игра
        static int Speed = 100;


        static void Main(string[] args)
        {
            FieldDrawer.Shift = FieldShift;
            FieldDrawer.BorderChar = BorderChar;
            FieldDrawer.CellChar = CellChar;
            FieldDrawer.CursorColor = CursorColor;
            ColoredFieldDrawer.CellColor = CellColor;
            ColoredFieldDrawer.BorderColor = BorderColor;

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
                    Thread.Sleep(Speed);

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
                if (keyInfo.Key == ConsoleKey.Spacebar)
                {
                    var cell = field[cursor.X - FieldShift, cursor.Y - FieldShift];
                    cell.Alive = cell.Alive ? false : true;
                }

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow: cursor.MoveUp(); break;
                    case ConsoleKey.DownArrow: cursor.MoveDown(); break;
                    case ConsoleKey.LeftArrow: cursor.MoveLeft(); break;
                    case ConsoleKey.RightArrow: cursor.MoveRight(); break;
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
                    ShowError("Неккоректная длинна поля!");
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
                    return new ColoredFieldDrawer(field);
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
    }
}
