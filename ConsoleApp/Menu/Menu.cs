using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp.Menu
{
    class Menu
    {
        List<BaseMenuItem> items;

        public Menu() => items = new List<BaseMenuItem>();

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("Игра \"Жизнь\" Джона Конвея");
            Console.WriteLine("Меню:");
            foreach (var item in items)
                Console.WriteLine($"{item.Id} - {item.Text}");
        }

        public void SelectItem(string itemId)
        {
            var item = items.FirstOrDefault(x => x.Id == itemId);
            if (item is null)
                ShowError();
            else
                item.Operation();
            ShowBack();
        }
    

        private void ShowError()
        {
            Console.Clear();
            Console.WriteLine("Выберите корректный пункт меню!");
        }

        private void ShowBack()
        {
            Console.WriteLine();
            Console.WriteLine("Нажмите любую кнопку, чтобы вернуться в главное меню");
            Console.ReadKey();
        }

        public void AddItem(BaseMenuItem item) => items.Add(item);
    }
}
