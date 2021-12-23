using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space.Functions
{
    /// <summary>
    /// Абстрактный класс функции
    /// </summary>
    public abstract class Function
    {
        /// <summary>
        /// Вычислить функцию
        /// </summary>
        /// <param name="x">Коорината x</param>
        /// <param name="y">Коорината y</param>
        /// <returns>Значение</returns>
        public abstract double calk(double x, double y);
    }
}
