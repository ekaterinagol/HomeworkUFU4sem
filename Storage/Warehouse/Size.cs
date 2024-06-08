using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    public class Size
    {
        public int Length { get; }
        public int Width { get; }
        public int Height { get; }

        public Size(int length, int width, int height)
        {
            if (length <= 0 || width <= 0 || height <= 0)
                throw new ArgumentException("Неположительный размер");

            Length = length;
            Width = width;
            Height = height;
        }
    }
}
