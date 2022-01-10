using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space.Functions
{
    /// <summary>
    /// Унимодальная функция №2
    /// </summary>
    public class Unimodal2 : Function
    {
        /// <summary>
        /// Вычислить функцию
        /// </summary>
        /// <param name="x">Координата x</param>
        /// <param name="y">Координата y</param>
        /// <returns>Значение</returns>
        public override double calk(double x, double y)
        {
            return 0.26 * (x * x + y * y) - 0.48 * x * y;
        }
    }
}

