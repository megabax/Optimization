using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space.Functions
{
    /// <summary>
    /// Сферическая функция
    /// </summary>
    public class Sphere : Function
    {
        /// <summary>
        /// Вычислить функцию
        /// </summary>
        /// <param name="x">Координата x</param>
        /// <param name="y">Координата y</param>
        /// <returns>Значение</returns>
        public override double calk(double x, double y)
        {
            return x * x + y * y;
        }
    }
}
