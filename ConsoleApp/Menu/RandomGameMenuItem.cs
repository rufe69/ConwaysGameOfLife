using ConwaysGameOfLife;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApp.Menu
{
    class RandomGameMenuItem : BaseMenuItem
    {
        public RandomGameMenuItem(string id) : base(id) => Text = "случайно сгенерированное игровое поле";

        public override void Operation()
        {
            Console.Clear();
            Console.WriteLine("Введите длину поля");
            var length = Console.ReadLine();
            var field = new Field(int.Parse(length));

            var rnd = new Random();
            for (int i = 0; i < field.Length; i++)
                for (int j = 0; j < field.Length; j++)
                    field[i, j].Alive = rnd.Next(0, 2) == 0 ? false : true;

            //StartGame(field);
        }
    }
}
