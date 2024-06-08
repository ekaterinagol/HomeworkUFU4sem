using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    public class MarkedProduct : Product, IMarked
    {
        public ulong Barcode { get; }

        public MarkedProduct(string name, Size dimensions, double weight, ulong barcode)
            : base(name, dimensions, weight)
        {
            if (barcode == 0 || barcode.ToString().Length != 13)
                throw new ArgumentException("Штрихкод EAN-13 (только цифры)");

            Barcode = barcode;
        }   
    }
}
