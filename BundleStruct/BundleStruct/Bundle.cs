using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundleStruct
{
    public class Bundle
    {
        public int Count { get; set; }
        public int Sum { get; set; }

        int bancknote;
        public int Banknote
        {
            get => bancknote;
            set
            {
                if (value==1 || value == 2 || value == 5 || value == 10 || value == 50 || value == 100 || value == 200 || value == 500 || value == 1000 || value == 2000 || value == 5000)
                    bancknote = value;

                throw new ArgumentException("Номинал банкноты может принимать только определенные значения");
            }
        }
    }
}
