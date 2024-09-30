using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Menus
{
    /// <summary>
    /// Интерфейс для меню
    /// </summary>
    internal interface IMenu
    {
        /// <summary>
        /// Показать меню
        /// </summary>
        void Show();

        /// <summary>
        /// Показать сообщение об ошибке
        /// </summary>
        /// <param name="message">Сообщение</param>
        void ShowError(string message);
    }
}
