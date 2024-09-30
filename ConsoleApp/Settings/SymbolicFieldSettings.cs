using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Settings
{
    internal class SymbolicFieldSettings
    {
        /// <summary>
        /// Символ границы (при выборе символьного поля)
        /// </summary>
        public char BorderChar { get; set; } = '#';

        /// <summary>
        /// Символ ячейки (при выборе символьного поля)
        /// </summary>
        public char CellChar { get; set; } = '*';
    }
}
