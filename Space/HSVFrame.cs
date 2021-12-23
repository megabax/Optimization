using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SASSDI
{
    /// <summary>
    /// Кадр изображения
    /// </summary>
    public class HSVFrame
    {
        /// <summary>
        /// Матрица
        /// </summary>
        public FramePoint[,] matrix;

        /// <summary>
        /// Картинка
        /// </summary>
        public Bitmap picture;

        /// <summary>
        /// Ширина
        /// </summary>
        public int width;

        /// <summary>
        /// Высота
        /// </summary>
        public int height;

        public HSVFrame()
        {
            height = 0;
            width = 0;
            matrix = null;
        }


        /// <summary>
        /// Посчитать количество соседей заданной точки
        /// </summary>
        /// <param name="x">Координата x</param>
        /// <param name="y">Коордианата y</param>
        /// <returns>Результат</returns>
        public int get_neighbor(int x, int y)
        {
            int res = 0;
            if (is_neighbor(x - 1, y - 1)) res++;
            if (is_neighbor(x, y - 1)) res++;
            if (is_neighbor(x + 1, y - 1)) res++;
            if (is_neighbor(x + 1, y)) res++;
            if (is_neighbor(x + 1, y + 1)) res++;
            if (is_neighbor(x, y - 1)) res++;
            if (is_neighbor(x - 1, y + 1)) res++;
            if (is_neighbor(x - 1, y)) res++;
            return res;
        }

        /// <summary>
        /// Есть ли соссед в пикселе с указанными координатами
        /// </summary>
        /// <param name="x">Координата x</param>
        /// <param name="y">Координата y</param>
        /// <returns>true - есть, false - нет</returns>
        public bool is_neighbor(int x, int y)
        {
            if (x < 0) return false;
            if (y < 0) return false;
            if (y >= height) return false;
            if (x >= width) return false;
            return matrix[x, y].V > 0.5;
        }




        /// <summary>
        /// Получить список разрешенных направлений для заданного направления
        /// </summary>
        /// <param name="dir">Рассматрвиаемое направление</param>
        /// <returns>Список разрешенных направлений</returns>
        public List<int> get_allowed_dirs(int dir)
        {
            List<int> res = new List<int>();
            switch (dir)
            {
                case 0:
                    res.Add(7);
                    res.Add(0);
                    res.Add(1);
                    break;
                case 1:
                    res.Add(7);
                    res.Add(0);
                    res.Add(1);
                    res.Add(2);
                    res.Add(3);
                    break;
                case 2:
                    res.Add(1);
                    res.Add(2);
                    res.Add(3);
                    break;
                case 3:
                    res.Add(5);
                    res.Add(4);
                    res.Add(3);
                    res.Add(2);
                    res.Add(1);
                    break;
                case 4:
                    res.Add(5);
                    res.Add(4);
                    res.Add(3);
                    break;
                case 5:
                    res.Add(3);
                    res.Add(4);
                    res.Add(5);
                    res.Add(6);
                    res.Add(7);
                    break;
                case 6:
                    res.Add(5);
                    res.Add(6);
                    res.Add(7);
                    break;
                case 7:
                    res.Add(5);
                    res.Add(6);
                    res.Add(7);
                    res.Add(0);
                    res.Add(1);
                    break;
            }
            return res;
        }




        /// <summary>
        /// Конструктор по ширине и высоте фрейма
        /// </summary>
        /// <param name="a_width">Ширина</param>
        /// <param name="a_height">Высота</param>
        public HSVFrame(int a_width, int a_height)
        {
            matrix = new FramePoint[a_width, a_height];
            height = a_height;
            width = a_width;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    matrix[i, j] = new FramePoint();
                }
            }
        }

        /// <summary>
        /// Конструктор файлу картинки
        /// </summary>
        /// <param name="file_name">Имя открываемого файла</param>
        public HSVFrame(string file_name)
        {
            create_matrix(file_name);
        }


        /// <summary>
        /// Создать картинку
        /// </summary>
        public void create_picture()
        {
            picture = new Bitmap(width, height);
            using (var wrapper = new ImageWrapper(picture, true))
            {
                for (int i = 0; i < wrapper.Width; i++)
                {
                    for (int j = 0; j < wrapper.Height; j++)
                    {
                        Color color = matrix[i, j].get_color();
                        wrapper[i, j] = color;
                    }
                }
            }
        }

        /// <summary>
        /// Создать матрицу
        /// </summary>
        /// <param name="file_name">Имя открываемого файла</param>
        public void create_matrix(string file_name)
        {
            picture = new Bitmap(file_name);
            using (var wrapper = new ImageWrapper(picture, true))
            {
                width = wrapper.Width;
                height = wrapper.Height;
                matrix = new FramePoint[width, height];
                for (int i = 0; i < wrapper.Width; i++)
                {
                    for (int j = 0; j < wrapper.Height; j++)
                    {
                        Color color = wrapper[i, j];
                        matrix[i, j] = new FramePoint(color.R, color.G, color.B);
                    }
                }
            }
        }
    }
}
