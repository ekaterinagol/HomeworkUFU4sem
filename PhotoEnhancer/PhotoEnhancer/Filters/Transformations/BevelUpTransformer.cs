using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer.Filters.Transformations
{
    public class BevelUpTransformer : ITransformer<BevelParameters>
    {
        double alpha;
        Size oldSize;
        public Size ResultSize { get; private set; }

        public void Initialize(Size oldSize, BevelParameters parameters)
        {
            this.oldSize = oldSize;
            alpha = parameters.AngleInDegrees * Math.PI / 180;
            ResultSize = new Size(
                    oldSize.Width,
                    (int)(oldSize.Height + oldSize.Width * Math.Abs(Math.Tan(alpha)))
                    );
        }

        public Point? MapPoint(Point newPoint)
        {
            var p = new Point(newPoint.X - ResultSize.Width / 2, newPoint.Y - ResultSize.Height / 2);
            var x = (int)(newPoint.X);
            var y = (int)(oldSize.Height / 2 - p.X * Math.Tan(alpha)+ p.Y);

            if (x < 0 || x >= oldSize.Width || y < 0 || y >= oldSize.Height)
                return null;

            return new Point(x, y);
        }
    }
}

