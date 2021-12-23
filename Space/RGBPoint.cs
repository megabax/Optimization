using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SASSDI
{
    /// <summary>
    /// Описание цвета точки в формате RGB с возможностью отрицатльных значнеий,
    /// которые могут возникнуть при вычиатнии фраймов
    /// </summary>
    public class RGBPoint
    {
        /// <summary>
        /// Компонента красного
        /// </summary>
        public int R;

        /// <summary>
        /// Компонента зеленого
        /// </summary>
        public int G;

        /// <summary>
        /// Комоенента синего
        /// </summary>
        public int B;

        public RGBPoint()
        {
        }

        /// <summary>
        /// Конструтор по трем цветам
        /// </summary>
        /// <param name="a_R">Красный</param>
        /// <param name="a_G">Зеленый</param>
        /// <param name="a_B">Синий</param>
        public RGBPoint(int a_R, int a_G, int a_B)
        {
            R = a_R;
            G = a_G;
            B = a_B;
        }

        /// <summary>
        /// Получить цвет
        /// </summary>
        /// <returns>Цвет</returns>
        public Color get_color()
        {
            return Color.FromArgb(R, G, B);
        }
        
        /// <summary>
        /// Создать копию
        /// </summary>
        /// <returns>Копия</returns>
        public RGBPoint clone()
        {
            RGBPoint res = new RGBPoint();
            res.B = B;
            res.G = G;
            res.R = R;
            return res;
        }

        /// <summary>
        /// Получить среднюю яроксть пикселя
        /// </summary>
        /// <returns>Яркость</returns>
        public int light()
        {
            return (R + G + B) / 3;
        }

        /// <summary>
        /// Устанвоить 
        /// </summary>
        /// <param name="a_color">Установить из цвета</param>
        public void set_from_color(Color a_color)
        {
            R = a_color.R;
            G = a_color.G;
            B = a_color.B;
        }
    }
}
