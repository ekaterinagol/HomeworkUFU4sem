using PhotoEnhancer.Filters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoEnhancer
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = new MainForm();
            //mainForm.AddFilter(new LighteningFilter());
            //mainForm.AddFilter(new GrayScaleFilter());
            //mainForm.AddFilter(new HueFilter());

            mainForm.AddFilter(new PixelFilter<LighteningParameters>(
                "Осветление/затемнение",
                (p, parameters) => p * parameters.Coefficient
                ));

            mainForm.AddFilter(new PixelFilter<EmptyParameters>(
                "Оттенки серого",
                (p, parameters) =>
                {
                    var lightness = 0.3 * p.R + 0.6 * p.G + 0.1 * p.B;
                    return new Pixel(lightness, lightness, lightness);
                }
                ));

            mainForm.AddFilter(new PixelFilter<RangeUpperParameters>(
                "Сужение диапазона",
                (p, parameters) =>
                {

                    var RangeR = (parameters.Upper - parameters.Lower) * p.R + parameters.Lower;
                    var RangeG = (parameters.Upper - parameters.Lower) * p.G + parameters.Lower;
                    var RangeB = (parameters.Upper - parameters.Lower) * p.B + parameters.Lower;

                    return new Pixel(RangeR, RangeG, RangeB);
                }
                ));

            mainForm.AddFilter(new TransformFilter(
                "Отражение по горизонтали",
                size => size,
                (point, size) => new Point(size.Width - point.X - 1, point.Y)
                ));

            mainForm.AddFilter(new TransformFilter(
               "Поворот на 90° против ч.с.",
               size => new Size(size.Height, size.Width),
               (point, size) => new Point(size.Width - point.Y - 1, point.X)
               ));

            mainForm.AddFilter(new TransformFilter(
                "Поворот на 180° против ч.с.",
                size => size,
                (point, size) => new Point(size.Width - point.X - 1, size.Height - point.Y - 1)
                ));



            //mainForm.AddFilter(new TransformFilter(
            //    "Отражение по горизонтали",
            //    size => size,
            //    (point, size) => new Point(size.Width - point.X - 1, point.Y)
            //    ));

            //mainForm.AddFilter(new TransformFilter(
            //    "Поворот на 90° против ч.с.",
            //    size => new Size(size.Height, size.Width),
            //    (point, size) => new Point(size.Width - point.Y - 1, point.X)
            //    ));

            //mainForm.AddFilter(new TransformFilter<RotationParameters>(
            //    "Поворот на произвольный угол", new RotationTransformer()));

            Application.Run(mainForm);
        }
    }
}