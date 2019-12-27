using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Menu
{
    class RulesMenuItem : BaseMenuItem
    {
        public RulesMenuItem(string id) : base(id) => Text = "правила игры";

        public override void Operation()
        {
            Console.Clear();
            Console.WriteLine("Правила игра");
            Console.WriteLine("# Место действия этой игры — это размеченная на клетки поверхность замкнутая в виде тора.");
            Console.WriteLine("# Каждая клетка на этой поверхности может находиться в двух состояниях: быть живой или быть мёртвой. Клетка имеет восемь соседей, окружающих её.");
            Console.WriteLine("# Распределение живых клеток в начале игры называется первым поколением.");
            Console.WriteLine();
            Console.WriteLine("Правила распределения клеток по полю в следующих поколениях:");
            Console.WriteLine("# В мёртвой клетке, рядом с которой ровно три живые клетки, зарождается жизнь.");
            Console.WriteLine("# Если у живой клетки есть ровно две или ровно три живые соседки, то эта клетка продолжает жить иначе клетка умирает.");
            Console.WriteLine();
            Console.WriteLine("Игра прекращается, если:");
            Console.WriteLine("# На поле не останется ни одной живой клетки.");
            Console.WriteLine("# Конфигурация на очередном шаге в точности повторит себя же на одном из более ранних шагов.");
            Console.WriteLine("# При очередном шаге ни одна из клеток не меняет своего состояния.");

        }
    }
}
