using ConwaysGameOfLife;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApp.Menu
{
    class CustomGameMenuItem:BaseMenuItem
    {
        public CustomGameMenuItem(string id) : base(id) => Text = "установить игровое поле";

        public override void Operation()
        {
            Console.Clear();
            var field = new Field(10);
            field[0, 2].Alive = true;
            field[1, 0].Alive = true;
            field[1, 2].Alive = true;
            field[2, 1].Alive = true;
            field[2, 2].Alive = true;


            var game = new Game(field);
            Console.Clear();
            var drawer = new FieldDrawer(field);
            drawer.DrawFieldBorders();
            drawer.DrawField();
            while (!game.Played)
            {
                game.NextGeneration();
                drawer.DrawField();
                Thread.Sleep(100);
            }
        }
    }
}
