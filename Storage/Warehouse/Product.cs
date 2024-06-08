using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    public class Product
    {
        public string Name { get; }
        public Size Dimensions { get; }
        public double Weight { get; }

        public Product(string name, Size dimensions, double weight)
        {
            Name = name;
            Dimensions = dimensions;
            Weight = weight;
        }
    }
}
