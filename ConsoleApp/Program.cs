using ConsoleApp.Menu;
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
            var menu = new Menu();
            menu.AddItem(new CustomGameMenuItem("1"));
            menu.AddItem(new RandomGameMenuItem("2"));
            menu.AddItem(new RulesMenuItem("3"));
            menu.AddItem(new ExitMenuItem("4"));

            while (true)
            {
                menu.Show();
                var itemId = Console.ReadLine();
                menu.SelectItem(itemId);
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


        static void StartRandomGame()
        {
            
        }



        /*

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
