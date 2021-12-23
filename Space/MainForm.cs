using SASSDI;
using Space.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space
{
    //https://ru.wikipedia.org/wiki/%D0%A2%D0%B5%D1%81%D1%82%D0%BE%D0%B2%D1%8B%D0%B5_%D1%84%D1%83%D0%BD%D0%BA%D1%86%D0%B8%D0%B8_%D0%B4%D0%BB%D1%8F_%D0%BE%D0%BF%D1%82%D0%B8%D0%BC%D0%B8%D0%B7%D0%B0%D1%86%D0%B8%D0%B8
    //https://habr.com/ru/company/skillfactory/blog/549472/
    public partial class MainForm : Form
    {
        /// <summary>
        /// Масштаб
        /// </summary>
        private double _Ratio = 0.05;

        /// <summary>
        /// Максимальное значение координаты
        /// </summary>
        private double _MaxXY=10;

        /// <summary>
        /// Карта
        /// </summary>
        private double[,] _Map;

        /// <summary>
        /// Размер массива
        /// </summary>
        private int _Size;

        /// <summary>
        /// Минимальное значение функции
        /// </summary>
        private double _Min;

        /// <summary>
        /// Максимальное значение функции
        /// </summary>
        private double _Max;

        /// <summary>
        /// Фрейм
        /// </summary>
        private RGBFrame _Frame;

        /// <summary>
        /// Функция
        /// </summary>
        private Function _Function;

        public MainForm()
        {
            InitializeComponent();
            _Size = Convert.ToInt32(_MaxXY / _Ratio) * 2 + 1;
            _Map = new double[_Size, _Size];
        }

        private void btnSphere_Click(object sender, EventArgs e)
        {
            _Function = new Sphere();
            CreateSurface();
        }

        private int GetR(double val)
        {
            if (val > 0.75) return 255;
            if (val < 0.5) return 0;
            int res= Convert.ToInt32((val - 0.5) * 1020.0);
            if (res < 0 || res > 255) throw new Exception("Выход за пределы диапазона R "+val);
            return res;
        }

        private int GetG(double val)
        {
            if (val > 0.75) return 255 - Convert.ToInt32((val - 0.75) * 1020.0);
            if (val < 0.75 && val > 0.5) return 255;
            if (val <= 0.25) return 0;
            return Convert.ToInt32((val - 0.25) * 1020.0); ;
            /*if (val < 0.5) return 0;
            int res = Convert.ToInt32((val - 0.5) * 1020.0);
            if (res < 0 || res > 255) throw new Exception("Выход за пределы диапазона G " + val);
            return res; */
            //if (val >= 0.5 && val < 0.75) return 255 - Convert.ToInt32((val-0.));
            //return Convert.ToInt32((0.5 - Math.Abs(val - 0.5)) * 510.0);
        }

        /// <summary>
        /// Отобразить карту
        /// </summary>
        private void DrawMap()
        {
            _Frame = new RGBFrame(_Size,_Size);
            for (int xt = 0; xt < _Size; xt++)
            {
                for (int yt = 0; yt < _Size; yt++)
                {
                    double val = (_Map[xt, yt] - _Min) / (_Max - _Min);
                    int gray = Convert.ToInt32(val * 255.0);
                    int R = gray;
                    int G = gray;
                    int B = gray;//255 - Convert.ToInt32(val * 255.0);
                    _Frame.matrix[xt, yt] = new RGBPoint(R, G, B);
                }
            }
            _Frame.create_picture();
            pbMain.Image = _Frame.picture;
        }

        private void btnOptimize_Click(object sender, EventArgs e)
        {
            List<Tuple<double, double, double>> path = new List<Tuple<double, double, double>>();
            double begx = Constants.rnd.NextDouble() * 2.0 * _MaxXY - _MaxXY;
            double begy = Constants.rnd.NextDouble() * 2.0 * _MaxXY - _MaxXY;
            double lastf = _Function.calk(begx, begy);
            double x = begx;
            double y = begy;
            double currf = lastf;
            path.Add(new Tuple<double, double, double>(begx, begy, currf));
            for (int i=1; i<=100; i++)
            {
                double newx = Constants.rnd.NextDouble()-0.5+x;
                double newy = Constants.rnd.NextDouble()-0.5+y;
                double newf = _Function.calk(newx, newy);
                if(newf<currf)
                {
                    x = newx;
                    y = newy;
                    currf = newf;
                }
                path.Add(new Tuple<double, double,double>(x, y, currf));
            }
            DrawPath(path);
        }

        private void DrawPath(List<Tuple<double, double, double>> path)
        {
            chart.Series[0].Points.Clear();

            foreach (Tuple<double, double,double> point in path)
            {
                //double x = Convert.ToDouble(xt) * _Ratio - _MaxXY;
                double x = point.Item1;
                double y = point.Item2;
                int xt = Convert.ToInt32((x+_MaxXY)/_Ratio);
                int yt = Convert.ToInt32((y + _MaxXY) / _Ratio);
                _Frame.matrix[xt, yt] = new RGBPoint(255, 0, 0);
                chart.Series[0].Points.AddY(point.Item3);
            }
            _Frame.create_picture();
            pbMain.Image = _Frame.picture;            
        }

        private void btnLineOpt_Click(object sender, EventArgs e)
        {
            List<Tuple<double, double, double>> path = new List<Tuple<double, double, double>>();
            double begx = Constants.rnd.NextDouble() * 2.0 * _MaxXY - _MaxXY;
            double begy = Constants.rnd.NextDouble() * 2.0 * _MaxXY - _MaxXY;
            double lastf = _Function.calk(begx, begy);
            double x = begx;
            double y = begy;
            double currf = lastf;
            path.Add(new Tuple<double, double, double>(begx, begy, currf));
            for (int i = 1; i <= 1000; i++)
            {
                double fullRound = Math.PI * 2.0;
                double delta = fullRound / 30.0;
                double r = 0.1;
                for (double al=0; al< fullRound; al+=delta)
                {
                    double newx = x+Math.Sin(al)*r;
                    double newy = y+Math.Cos(al)*r;
                    double newf = _Function.calk(newx, newy);
                    if (newf < currf)
                    {
                        x = newx;
                        y = newy;
                        currf = newf;
                    }
                }

                path.Add(new Tuple<double, double, double>(x, y, currf));
            }
            DrawPath(path);
        }

        private void btnLineOpt2_Click(object sender, EventArgs e)
        {
            List<Tuple<double, double, double>> path = new List<Tuple<double, double, double>>();
            double begx = Constants.rnd.NextDouble() * 2.0 * _MaxXY - _MaxXY;
            double begy = Constants.rnd.NextDouble() * 2.0 * _MaxXY - _MaxXY;
            double lastf = _Function.calk(begx, begy);
            double x = begx;
            double y = begy;
            double currf = lastf;
            double r = 0.2;
            path.Add(new Tuple<double, double, double>(begx, begy, currf));
            for (int i = 1; i <= 1000; i++)
            {
                double fullRound = Math.PI * 2.0;
                double delta = fullRound / 30.0;               
                for (double al = 0; al < fullRound; al += delta)
                {
                    double newx = x + Math.Sin(al) * r;
                    double newy = y + Math.Cos(al) * r;
                    double newf = _Function.calk(newx, newy);
                    if (newf < currf)
                    {
                        x = newx;
                        y = newy;
                        currf = newf;
                    }
                }
                r /= 1.1;

                path.Add(new Tuple<double, double, double>(x, y, currf));
            }
            DrawPath(path);
        }

        private void btnUnimodal2_Click(object sender, EventArgs e)
        {
            _Function = new Unimodal2();
            CreateSurface();
        }

        private void CreateSurface()
        {
            _Min = double.MaxValue;
            _Max = double.MinValue;
            for (int xt = 0; xt < _Size; xt++)
            {
                for (int yt = 0; yt < _Size; yt++)
                {
                    double x = Convert.ToDouble(xt) * _Ratio - _MaxXY;
                    double y = Convert.ToDouble(yt) * _Ratio - _MaxXY;
                    double val = _Function.calk(x, y);
                    if (val > _Max) _Max = val;
                    if (val < _Min) _Min = val;
                    _Map[xt, yt] = val;
                }
            }
            DrawMap();
        }

        private void btnIzom_Click(object sender, EventArgs e)
        {
            _Function = new Izom();
            CreateSurface();
        }
    }
}
