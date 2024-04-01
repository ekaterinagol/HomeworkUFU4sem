using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundleStruct
{
    public class Bundle
    {

        int bancknote;
        public int Banknote
        {
            get => bancknote;
            set
            {
                if (value==1 || value == 2 || value == 5 || value == 10 || value == 50 || value == 100 || value == 200 || value == 500 || value == 1000 || value == 2000 || value == 5000)
                    bancknote = value;
                else
                    throw new ArgumentException("Номинал банкноты может принимать только определенные значения.");
            }
        }

        int count;
        public int Count
        {
            get => count;
            set
            {
                if (value<=0)
                    throw new ArgumentException("Количество купюр в пачке не может быть отрицательным.");

                count = value;
            }
        }

        public int Sum 
        {
            get => Banknote * Count;
        }
    }
}
