using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Settings
{
    internal class ColoredFieldSettings
    {
        /// <summary>
        /// Цвет границы (при выборе цветного поля)
        /// </summary>
        public ConsoleColor BorderColor { get; set; } = ConsoleColor.Red;

        /// <summary>
        /// Свет клетки (при выборе цветного поля)
        /// </summary>
        public ConsoleColor CellColor { get; set; } = ConsoleColor.Green;

        /// <summary>
        /// Цвет курсора (при выборе цветного поля)
        /// </summary>
        public ConsoleColor CursorColor { get; set; } = ConsoleColor.Gray;
    }
}
