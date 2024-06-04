using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoEnhancer
{
    public static class Convertors
    {
        public static Photo BitmapToPhoto(Bitmap bmp)
        {
            var photo = new Photo(bmp.Width, bmp.Height);

            for (int x = 0; x < bmp.Width; x++)
                for (int y = 0; y < bmp.Height; y++)
                {
                    var p = bmp.GetPixel(x, y);

                    photo[x, y] = new Pixel(
                        p.R / 255.0,
                        p.G / 255.0,
                        p.B / 255.0
                        );

                    //photo[x,y].R = p.R / 255.0;
                    //photo[x,y].G = p.G / 255.0;
                    //photo[x,y].B = p.B / 255.0;
                }

            return photo;
        }

        public static Bitmap PhotoToBitmap(Photo photo)
        {
            var bmp = new Bitmap(photo.Width, photo.Height);

            for (int x = 0; x < bmp.Width; x++)
                for (int y = 0; y < bmp.Height; y++)
                    bmp.SetPixel(x, y,
                        Color.FromArgb(
                            (int)Math.Round(photo[x, y].R * 255),
                            (int)Math.Round(photo[x, y].G * 255),
                            (int)Math.Round(photo[x, y].B * 255)
                            )
                    );
            return bmp;
        }

        public static PixelHSL RGBToHSL(Pixel p)
        {
            //R, G and B input range = 0 ÷ 255
            //H, S and L output range = 0 ÷ 1.0

            var varMin = Math.Min(Math.Min(p.R, p.G), p.B);    //Min. value of RGB
            var varMax = Math.Max(Math.Max(p.R, p.G), p.B);    //Max. value of RGB
            var delMax = varMax - varMin;                    //Delta RGB value

            var lightness = (varMax + varMin) / 2;

            double hue = 0, saturation = 0; //This is a gray, no chroma...

            if (delMax != 0)   //Chromatic data...                  
            {
                if (lightness < 0.5)
                    saturation = delMax / (varMax + varMin);
                else
                    saturation = delMax / (2 - varMax - varMin);

                var delR = (((varMax - p.R) / 6) + (delMax / 2)) / delMax;
                var delG = (((varMax - p.G) / 6) + (delMax / 2)) / delMax;
                var delB = (((varMax - p.B) / 6) + (delMax / 2)) / delMax;

                if (p.R == varMax)
                    hue = delB - delG;
                else if (p.G == varMax)
                    hue = (1.0 / 3) + delR - delB;
                else if (p.B == varMax)
                    hue = (2.0 / 3) + delG - delR;

                if (hue < 0) hue += 1;
                if (hue > 1) hue -= 1;
            }

            return new PixelHSL(hue, saturation, lightness);
        }
    }
}
