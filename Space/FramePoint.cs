using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SASSDI
{

    //http://www.purebasic.info/phpBB3ex/viewtopic.php?p=36724
    /// <summary>
    /// Точка кадра изображения
    /// </summary>
    public class FramePoint
    {
        /// <summary>
        /// Hue - (сам цвет), от 0 до 1
        /// </summary>
        public double H;

        /// <summary>
        /// Saturation — насыщенность. Варьируется в пределах 0—1 
        /// </summary>
        public double S;

        /// <summary>
        /// Value (значение цвета) или Brightness — яркость. Также задаётся в пределах 0—1 
        /// </summary>
        public double V;

        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public FramePoint()
        {
        }

        /// <summary>
        /// Констурктор по HSV
        /// </summary>
        /// <param name="AH">H</param>
        /// <param name="AS">S</param>
        /// <param name="AV">V</param>
        public FramePoint(double AH, double AS, double AV)
        {
            H = AH;
            S = AS;
            V = AV;
        }

        /// <summary>
        /// Установить канала
        /// </summary>
        /// <param name="achannel">Канал</param>
        /// <param name="aval">Значение</param>
        public void set_channel(char achannel, double aval)
        {
            switch (achannel)
            {
                case 'v': V = aval;
                    break;
                case 'V': V = aval;
                    break;
                case 'h': H = aval;
                    break;
                case 'H': H = aval;
                    break;
                case 's': S = aval;
                    break;
                case 'S': S = aval;
                    break;
            }
        }

        /// <summary>
        /// Получить значение канала по имени
        /// </summary>
        /// <param name="achannel">Имя канала</param>
        /// <returns>Значение канала</returns>
        public double get_channel(char achannel)
        {
            switch (achannel)
            {
                case 'v': return V;
                case 'V': return V;
                case 'h': return H;
                case 'H': return H;
                case 's': return S;
                case 'S': return S;
            }
            return 0;
        }


        /// <summary>
        /// Конструктор по RGB
        /// </summary>
        /// <param name="R">R</param>
        /// <param name="G">G</param>
        /// <param name="B">B</param>
        public FramePoint(byte R, byte G, byte B) 
        {
            set_from_RGB(R, G, B);
        }


        /// <summary>
        /// Установить из RGB
        /// </summary>
        /// <param name="R">R</param>
        /// <param name="G">G</param>
        /// <param name="B">B</param>
        public void set_from_RGB(byte R, byte G, byte B)
        {
            //RGB from 0 to 255
            double var_R = (Convert.ToDouble(R) / 255.0);                     
            double var_G = (Convert.ToDouble(G) / 255.0);
            double var_B = (Convert.ToDouble(B) / 255.0);
 
            double var_Min = Math.Min(Math.Min(var_R, var_G), var_B);    //Min. value of RGB
            double var_Max = Math.Max(Math.Max(var_R, var_G), var_B);    //Max. value of RGB
            double del_Max = var_Max - var_Min;             //Delta RGB value 
 
            V = var_Max;
 
            //This is a gray, no chroma...
            if ( del_Max == 0 )                     
            {
               H = 0;                                //HSV results from 0 to 1
               S = 0;
            }
            else                                    //Chromatic data...
            {
               S = del_Max / var_Max;
 
               double del_R = ( ( ( var_Max - var_R ) / 6.0 ) + ( del_Max / 2.0 ) ) / del_Max;
               double del_G = ( ( ( var_Max - var_G ) / 6.0 ) + ( del_Max / 2.0 ) ) / del_Max;
               double del_B = ( ( ( var_Max - var_B ) / 6.0 ) + ( del_Max / 2.0 ) ) / del_Max;
 
               if      ( var_R == var_Max ) H = del_B - del_G;
               else if ( var_G == var_Max ) H = (1.0 / 3.0) + del_R - del_B;
               else if ( var_B == var_Max ) H = (2.0 / 3.0) + del_G - del_R;
 
               if (H < 0) H += 1.0;
               if (H > 1) H -= 1.0;
            }

        }

        /// <summary>
        /// Получить цвет точки
        /// </summary>
        /// <returns>Цвет</returns>
        public Color get_color()
        {
            byte R,G,B;
            if (S == 0)                       //HSV from 0 to 1
            {
                R = Convert.ToByte(V * 255);
                G = Convert.ToByte(V * 255);
                B = Convert.ToByte(V * 255);
            }
            else
            {
                double var_h = H * 6;
                if (var_h == 6) var_h = 0;      //H must be < 1
                double var_i = Math.Floor(var_h);             //Or ... var_i = floor( var_h )
                double var_1 = V * (1 - S);
                double var_2 = V * (1 - S * (var_h - var_i));
                double var_3 = V * (1 - S * (1 - (var_h - var_i)));

                double var_r, var_g, var_b;

                if (var_i == 0) { var_r = V; var_g = var_3; var_b = var_1; }
                else if (var_i == 1) { var_r = var_2; var_g = V; var_b = var_1; }
                else if (var_i == 2) { var_r = var_1; var_g = V; var_b = var_3; }
                else if (var_i == 3) { var_r = var_1; var_g = var_2; var_b = V; }
                else if (var_i == 4) { var_r = var_3; var_g = var_1; var_b = V; }
                else { var_r = V; var_g = var_1; var_b = var_2; }

                R = Convert.ToByte(var_r * 255);                  //RGB results from 0 to 255
                G = Convert.ToByte(var_g * 255);
                B = Convert.ToByte(var_b * 255);
            }
            return Color.FromArgb(R, G, B);
        }

        /// <summary>
        /// Количество красного цвета
        /// </summary>
        //public byte R;

        /// <summary>
        /// Количество зеленого цвета
        /// </summary>
        //public byte G;

        /// <summary>
        /// Количество синего цвета
        /// </summary>
        //public byte B;
    }
}
