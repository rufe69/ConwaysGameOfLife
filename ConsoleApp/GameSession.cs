using ConsoleApp.Drawers;
using ConsoleApp.FieldFillers;
using ConsoleApp.Settings;
using ConwaysGameOfLife;
using GameOfLife;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class GameSession
    {
        private readonly IFieldFiller fieldFiller;
        private readonly Field field;
        private readonly FieldDrawer fieldDrawer;
        private int speed;

        public GameSession(IFieldFiller fieldFiller,
                           Field field,
                           FieldDrawer fieldDrawer)
        {
            this.fieldFiller = fieldFiller;
            this.field = field;
            this.fieldDrawer = fieldDrawer;
            speed = MainSettings.Instance.Speed;
        }

        public void Start()
        {
            fieldFiller.Fill(field);

            var cancelTknSrc = new CancellationTokenSource();
            var cancelToken = cancelTknSrc.Token;

            var task = new Task(() =>
            {
                Console.Clear();
                fieldDrawer.DrawFieldBorders();
                fieldDrawer.DrawField();
                var game = new Game(field);
                while (!game.State.IsEnd)
                {
                    game.NextGeneration();
                    fieldDrawer.DrawField();
                    Thread.Sleep(speed);

                    if (cancelToken.IsCancellationRequested)
                    {
                        Console.Clear();
                        return;
                    }
                }

                Console.WriteLine();
                Console.WriteLine($"Количество прожитых поколений - {game.CurrentGeneration}");
                Console.WriteLine(game.State.Status == GameStatus.Dead ? "Вселенная погибла" : "Жизнь во вселенной бесконечна");
            }, cancelToken);

            task.Start();
            Console.ReadKey();
            cancelTknSrc.Cancel();
            task.Wait();
        }
    }
}
