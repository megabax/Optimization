using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space.Functions
{
    /// <summary>
    /// Функция изома
    /// </summary>
    public class Izom : Function
    {
        /// <summary>
        /// Вычислить функцию
        /// </summary>
        /// <param name="x">Коорината x</param>
        /// <param name="y">Коорината y</param>
        /// <returns>Значение</returns>
        public override double calk(double x, double y)
        {
            return 1.0-Math.Cos(x) * Math.Cos(y) * Math.Exp(-(Math.Pow((x - Math.PI), 2) + Math.Pow((y - Math.PI), 2)));
        }
    }
}
