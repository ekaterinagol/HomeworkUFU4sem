using PhotoEnhancer.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer.Filters
{
    public class RangeDecreasingFilter : PixelFilter<RangeUpperParameters>
    {
        public override Pixel ProcessPixel(Pixel p, RangeUpperParameters parameters)
        {
            var RangeR = (parameters.Upper-parameters.Lower) * p.R + parameters.Lower;
            var RangeG = (parameters.Upper - parameters.Lower) * p.G + parameters.Lower;
            var RangeB = (parameters.Upper - parameters.Lower) * p.B + parameters.Lower;

            return new Pixel(RangeR, RangeG, RangeB);
        }

        public override string ToString()
        {
            return "Сужение диапазона";
        }
    }
}
