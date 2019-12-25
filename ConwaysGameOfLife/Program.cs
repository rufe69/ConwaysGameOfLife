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
            var Field = new Field(6);
            var game = new Game(Field);
            game.Start();
        }

        static void DrawFieldTemp(Field field)
        {
            for (int i = 0; i < field.Length; i++)
            {
                for (int j = 0; j < field.Length; j++)
                {
                    Console.Write(field[i, j].Alive ? "1" : "0");
                }
                Console.WriteLine();
            }
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
