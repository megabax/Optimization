using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SASSDI
{
    /// <summary>
    /// Кадр изображения в формате RGB
    /// </summary>
    public class RGBFrame
    {
        /// <summary>
        /// Ширина изображения
        /// </summary>
        public int width;

        /// <summary>
        /// Высота изображения
        /// </summary>
        public int height;

        /// <summary>
        /// Матрица изображения
        /// </summary>
        public RGBPoint[,] matrix;

        /// <summary>
        /// Картинка изображения
        /// </summary>
        public Bitmap picture;

        /// <summary>
        /// Конструктор по файлу картинки
        /// </summary>
        /// <param name="file_name">Имя открываемого файла</param>
        public RGBFrame(string file_name)
        {
            create_matrix(file_name);
        }

        /// <summary>
        /// Посчитать список соседей данной точки
        /// </summary>
        /// <param name="x">координата x точки</param>
        /// <param name="y">координата y точки</param>
        /// <returns>Количество соседей</returns>
        public List<Point> list_neighbors(int x, int y)
        {
            List<Point> res = new List<Point>();
            if (is_neighbor(x - 1, y - 1)) res.Add(new Point(x-1,y-1));
            if (is_neighbor(x, y - 1)) res.Add(new Point(x, y - 1));
            if (is_neighbor(x + 1, y - 1)) res.Add(new Point(x + 1, y - 1));
            if (is_neighbor(x + 1, y)) res.Add(new Point(x + 1, y));
            if (is_neighbor(x + 1, y + 1)) res.Add(new Point(x + 1, y + 1));
            if (is_neighbor(x, y + 1)) res.Add(new Point(x, y + 1));
            if (is_neighbor(x - 1, y + 1)) res.Add(new Point(x - 1, y + 1));
            if (is_neighbor(x - 1, y)) res.Add(new Point(x - 1, y));
            return res;
        }

        /// <summary>
        /// Это концевая точка
        /// </summary>
        /// <param name="x">Координата x</param>
        /// <param name="y">Координата y</param>
        /// <returns>true - это концевая точка, false - не концевая</returns>
        public bool is_end_point(int x, int y)
        {
            List<Point> list = list_neighbors(x, y);
            if (list.Count >= 3) return false; //если три и больше соседей - это точно не концевая точка
            if (list.Count < 2) return true; //если меньше двух соседей - это точно концевая тчока

            //теперь рассмотрим случай, когда соседних точек две - тут неоднозначность и нужна доп проверка
            if (Math.Abs(list[0].X - list[1].X) == 1 && Math.Abs(list[0].Y - list[1].Y) == 0) return true;
            if (Math.Abs(list[0].Y - list[1].Y) == 1 && Math.Abs(list[0].X - list[1].X) == 0) return true;
            return false;
        }

        /// <summary>
        /// Посчитать количество соседей данной точки
        /// </summary>
        /// <param name="x">координата x точки</param>
        /// <param name="y">координата y точки</param>
        /// <returns>Количество соседей</returns>
        public int count_neighbors(int x, int y)
        {
            int count = 0;
            if (is_neighbor(x - 1, y - 1)) count++;
            if (is_neighbor(x, y - 1)) count++;
            if (is_neighbor(x + 1, y - 1)) count++;
            if (is_neighbor(x + 1, y)) count++;
            if (is_neighbor(x + 1, y + 1)) count++;
            if (is_neighbor(x, y + 1)) count++;
            if (is_neighbor(x - 1, y + 1)) count++;
            if (is_neighbor(x - 1, y)) count++;
            return count;
        }

        /// <summary>
        /// Есть ли сосед в этой точке
        /// </summary>
        /// <param name="x">координата x точки</param>
        /// <param name="y">координата y точки</param>
        /// <returns>true - есть, false - нету</returns>
        public bool is_neighbor(int x, int y)
        {
            if (x < 0 || x >= width) return false;
            if (y < 0 || y >= height) return false;
            if (matrix[x, y] == null) return false;
            return matrix[x, y].light() > 250;
        }


        /// <summary>
        /// Преобразовать в формат HSV
        /// </summary>
        /// <returns>Кадр в формате HSV</returns>
        public HSVFrame get_HSV()
        {
            HSVFrame res = new HSVFrame(width, height);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Color color = Color.Black;
                    if (matrix[i, j] != null)
                    {
                        color = matrix[i, j].get_color();
                    }
                    res.matrix[i, j] = new FramePoint(color.R, color.G, color.B);
                }
            }
            return res;
        }

        /// <summary>
        /// Есть ли красный сосед в этой точке
        /// </summary>
        /// <param name="x">координата x точки</param>
        /// <param name="y">координата y точки</param>
        /// <returns>true - есть, false - нету</returns>
        public bool is_neighbor_red(int x, int y)
        {
            if (x < 0 || x >= width) return false;
            if (y < 0 || y >= height) return false;
            if (matrix[x, y] == null) return false;
            return matrix[x, y].R > 250 && matrix[x, y].G<250;
        }

        /// <summary>
        /// Посчитать количество красных соседей данной точки
        /// </summary>
        /// <param name="x">координата x точки</param>
        /// <param name="y">координата y точки</param>
        /// <returns>Количество соседей</returns>
        public int count_neighbors_red(int x, int y)
        {
            int count = 0;
            if (is_neighbor_red(x - 1, y - 1)) count++;
            if (is_neighbor_red(x, y - 1)) count++;
            if (is_neighbor_red(x + 1, y - 1)) count++;
            if (is_neighbor_red(x + 1, y)) count++;
            if (is_neighbor_red(x + 1, y + 1)) count++;
            if (is_neighbor_red(x, y + 1)) count++;
            if (is_neighbor_red(x - 1, y + 1)) count++;
            if (is_neighbor_red(x - 1, y)) count++;
            return count;
        }

        /// <summary>
        /// Конструктор по размеру матрицы
        /// </summary>
        /// <param name="a_width">Ширина</param>
        /// <param name="a_height">Высота</param>
        public RGBFrame(int a_width, int a_height)
        {
            width = a_width;
            height = a_height;
            matrix = new RGBPoint[width, height];
        }

        /// <summary>
        /// Применить пороговую фильтрацию  с двумя порогами
        /// </summary>
        /// <param name="threshold1">Порог 1</param>
        /// <param name="threshold1">Порог 2</param>
        /// <returns>Результат применения</returns>
        public RGBFrame apply_threshold(int threshold1, int threshold2)
        {
            RGBFrame res = new RGBFrame(width, height);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    RGBPoint color = matrix[i, j];
                    if (color != null)
                    {
                        double fl = color.R + color.G + color.B;
                        fl = fl / 3;
                        if (fl > threshold1)
                        {
                            res.matrix[i, j] = new RGBPoint(Convert.ToInt32(255), Convert.ToInt32(255), Convert.ToInt32(255));
                        }
                        else
                        {
                            if (fl > threshold2)
                            {
                                res.matrix[i, j] = new RGBPoint(Convert.ToInt32(255), Convert.ToInt32(0), Convert.ToInt32(0));
                            }
                            else
                            {
                                res.matrix[i, j] = new RGBPoint(Convert.ToInt32(0), Convert.ToInt32(0), Convert.ToInt32(0));
                            }
                        }
                        
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// Применить пороговую фильтрацию
        /// </summary>
        /// <param name="threshold">Порог</param>
        /// <returns>Результат применения</returns>
        public RGBFrame apply_threshold(int threshold)
        {
            RGBFrame res = new RGBFrame(width, height);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    RGBPoint color = matrix[i, j];
                    if (color != null)
                    {
                        double fl = color.R + color.G + color.B;
                        fl = fl / 3;
                        if (fl > threshold) fl = 255; else fl = 0;
                        res.matrix[i, j] = new RGBPoint(Convert.ToInt32(fl), Convert.ToInt32(fl), Convert.ToInt32(fl));
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// Определение локальных максимумов в градиенте
        /// </summary>
        /// <returns>Кадр, где выделены локальные максимумы</returns>
        public RGBFrame local_maxima()
        {
            RGBFrame res = new RGBFrame(width, height);
            for (int i = 0; i < width-1; i++)
            {
                for (int j = 0; j < height-1; j++)
                {
                    RGBPoint color = matrix[i, j];
                    if (color != null && matrix[i + 1, j] != null && matrix[i - 1, j] != null && matrix[i, j - 1]!=null &&
                        matrix[i, j+1]!=null)
                    {
                        double x_last = matrix[i - 1, j].light();
                        double curr = matrix[i, j].light();
                        double x_prev = matrix[i + 1, j].light();
                        double y_last = matrix[i, j-1].light();
                        double y_prev = matrix[i, j+1].light();
                        int fl=0;
                        if (x_last < curr && x_prev > curr) fl = 255; // локальный максимум по x
                        if (y_last < curr && y_prev > curr) fl = 255; // локальный максимум по y
                        res.matrix[i, j] = new RGBPoint(Convert.ToInt32(fl), Convert.ToInt32(fl), Convert.ToInt32(fl));
                    }
                }
            }
            return res;
        }


        /// <summary>
        /// Вычислить градиент
        /// </summary>
        /// <returns>Результатирующий кадр</returns>
        public RGBFrame rgb_gradient()
        {
            RGBFrame res = new RGBFrame(width, height);
            double s2 = Math.Sqrt(2) * 255.0;
            for (int i = 1; i < width - 1; i++)
            {
                for (int j = 1; j < height - 1; j++)
                {
                    double dx = matrix[i, j].light() - matrix[i - 1, j].light();
                    double dy = matrix[i, j].light() - matrix[i, j - 1].light();
                    double r = Math.Sqrt(dx * dx + dy * dy);
                    int v = Convert.ToInt32(r / s2 * 255);
                    res.matrix[i, j]=new RGBPoint(v,v,v);
                }
            }
            return res;
        }

        /// <summary>
        /// Вычислить градиент
        /// </summary>
        /// <returns>Результатирующий кадр</returns>
        public HSVFrame gradient()
        {
            HSVFrame res = new HSVFrame(width, height);
            double s2=Math.Sqrt(2)*255.0;
            for (int i = 1; i < width - 1; i++)
            {
                for (int j = 1; j < height - 1; j++)
                {
                    double dx = matrix[i, j].light() - matrix[i-1, j].light();
                    double dy = matrix[i, j].light() - matrix[i, j-1].light();
                    double r = Math.Sqrt(dx * dx + dy * dy);
                    double angle = Math.Atan(dx / dy);
                    res.matrix[i, j].V = r / s2 ;
                    if(double.IsNaN(angle))
                    {
                        res.matrix[i, j].H=0;
                        res.matrix[i, j].S=0;
                    }
                    else
                    {
                        res.matrix[i, j].H = angle / Math.PI / 2;
                        res.matrix[i, j].S = 1;
                    }
                }
            }
            return res;
        }


        /// <summary>
        /// Применить фильтр
        /// </summary>
        /// <param name="filter">Фильтр</param>
        /// <param name="delta">Полуразмер фильтра</param>
        /// <param name="using_mirror_addition">Использовать ли зеркальное дополнение, 0 - если не использовать, иначе размер</param>
        /// <returns>Результатирующий кадр</returns>
        public RGBFrame apply_filter(double[,] filter, int delta, int using_mirror_addition)
        {
            if (using_mirror_addition!=0)
            {
                RGBFrame tmp = mirror_addition(using_mirror_addition);
                RGBFrame tmp1 = tmp.apply_filter(filter, delta, 0);
                return tmp1.remove_border(using_mirror_addition);
            }

            int size = delta * 2 + 1;
            RGBFrame res = new RGBFrame(width,height);

            double summ = 0;
            for (int k = 0; k < size; k++)
            {
                for (int l = 0; l < size; l++)
                {
                    summ += filter[k, l];
                }
            }

            for (int i = delta; i < width-delta; i++)
            {
                for (int j = delta; j < height-delta; j++)
                {
                    double fl = 0;
                    for (int k = i - delta; k <= i + delta; k++)
                    {
                        for (int l = j - delta; l <= j + delta; l++)
                        {
                            RGBPoint color = matrix[k, l];
                            int x = k - (i - delta);
                            int y = l - (j - delta);
                            double light_filter = filter[x, y];
                            fl = fl + color.R * light_filter;
                            fl = fl + color.G * light_filter;
                            fl = fl + color.B * light_filter;
                        }
                    }
                    fl = fl / 3;
                    if (fl < 0) fl = 0;
                    if(fl>255) fl=255;

                    res.matrix[i, j] = new RGBPoint(Convert.ToInt32(fl),Convert.ToInt32(fl),Convert.ToInt32(fl));
                }
            }
            return res;
        }

        /// <summary>
        /// Создать из существующего цвета
        /// </summary>
        /// <param name="a_color">Существующий цвет</param>
        /// <returns>Копия цвета</returns>
        public static Color copy_color(Color a_color)
        {
            return Color.FromArgb(a_color.R, a_color.G, a_color.B);
        }

        /// <summary>
        /// Создать удалить рамку
        /// </summary>
        /// <param name="size">Размер рамки</param>
        /// <returns>Результатирующий кадр</returns>
        public RGBFrame remove_border(int size)
        {
            RGBFrame res = new RGBFrame(width-size*2,height-size*2);
            for (int i = size; i < width-size; i++)
            {
                for (int j = size; j < height-size; j++)
                {
                    res.matrix[i - size, j-size] = matrix[i, j].clone();
                }
            }
            return res;
        }

        /// <summary>
        /// Создать зеркальное дополнение картинки
        /// </summary>
        /// <param name="size">Размер рамки дополнения</param>
        /// <returns>Результатирующий кадр</returns>
        public RGBFrame mirror_addition(int size)
        {
            RGBFrame res = new RGBFrame(width+2*size,height+2*size);
            for (int i = 0; i < res.width; i++)
            {
                for (int j = 0; j < res.height; j++)
                {
                    //основное поле
                    if (i > size && i < width + size && j > size && j < height + size)
                    {
                        res.matrix[i, j] = matrix[i-size, j-size].clone();
                    }


                    //левый верхний угол
                    if(i<=size && j<=size)
                    {
                        res.matrix[i,j] = matrix[size-i,size-j].clone();
                    }

                    //верхняя кромка
                    if (i >= size && i<width + size && j <= size)
                    {
                        res.matrix[i, j] = matrix[i-size, size - j].clone();
                    }

                    
                    //правый верхний угол
                    if (i >= width + size && j <= size)
                    {
                        int d = i - (size + width);
                        res.matrix[i, j] = matrix[width-d-1, size - j].clone();
                    }

                    //правая кромка
                    if (i >= width + size && j > size && j<height+size)
                    {
                        int d = i - (size + width);
                        res.matrix[i, j] = matrix[width - d - 1, j-size].clone();
                    }

                    //правый нижний угол
                    if (i >= width + size && j >= height+size)
                    {
                        int dx = i - (size + width);
                        int dy = j - (size + height);
                        res.matrix[i, j] = matrix[width - dx - 1, height-dy-1].clone();
                    }

                    //нижняя кромка
                    if (i >= size && i < width + size && j >= height+size)
                    {
                        int dy = j - (size + height);
                        res.matrix[i, j] = matrix[i - size, height - dy - 1].clone();
                    }

                    //левый нижний угол
                    if (i <= size && j >= height + size)
                    {
                        int dy = j - (size + height);
                        res.matrix[i, j] = matrix[size - i, height - dy - 1].clone();
                    }

                    //левая кромка
                    if (i <= size && j > size && j<height+size)
                    {
                        res.matrix[i, j] = matrix[size - i, j-size].clone();
                    }

                }
            }
            return res;
        }

        /// <summary>
        /// Создать матрицу по файлу
        /// </summary>
        /// <param name="file_name">Имя открываемого файла</param>
        private void create_matrix(string file_name)
        {
            picture = new Bitmap(file_name);
            using (var wrapper = new ImageWrapper(picture, true))
            {
                width = wrapper.Width;
                height = wrapper.Height;
                matrix = new RGBPoint[width, height];
                for (int i = 0; i < wrapper.Width; i++)
                {
                    for (int j = 0; j < wrapper.Height; j++)
                    {
                        matrix[i, j] = new RGBPoint(wrapper[i, j].R, wrapper[i, j].G, wrapper[i, j].B);
                    }
                }
            }
        }

        /// <summary>
        /// Создать матрицу по файлу
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
                        if (matrix[i, j] != null)
                            wrapper[i, j] = Color.FromArgb(matrix[i, j].R, matrix[i, j].G, matrix[i, j].B);
                        else
                            wrapper[i, j] = Color.FromArgb(0, 0, 0);
                    }
                }
            }
        }
    }
}
