using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundleStruct
{
    public struct Bundle
    {
        int banknote;
        public int Banknote
        {
            get => banknote;
            set
            {
                if (value==1 || value == 2 || value == 5 || value == 10 || value == 50 || value == 100 || value == 200 || value == 500 || value == 1000 || value == 2000 || value == 5000)
                    banknote = value;

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

        public Bundle(int banknote, int count) : this()
        {
            Banknote = banknote;
            Count = count;
        }

        public override string ToString() => $"{Count} x {Banknote} р.";

        public override bool Equals(object obj)
        {
            if (obj is Bundle)
                return (Count == ((Bundle)obj).Count) && (Banknote == ((Bundle)obj).Banknote);

            throw new ArgumentException("Объект для сравнения не является углом.");
        }

        public override int GetHashCode() => (Count,Banknote).GetHashCode();

        public static bool operator ==(Bundle x, Bundle y) => x.Equals(y);
        public static bool operator !=(Bundle x, Bundle y) => !x.Equals(y);

        public static Bundle operator +(Bundle x, Bundle y)
        {
            if (x.Banknote != y.Banknote)
                throw new ArgumentException("Сложение проводится только над пачками одинаковых номиналов.");

            return new Bundle(x.Banknote, x.Count + y.Count);
        }

        public static Bundle operator -(Bundle x, Bundle y)
        {
            if (x.Banknote != y.Banknote)
                throw new ArgumentException("Вычитание проводится только над пачками одинаковых номиналов.");
            else if (x.Count < y.Count)
                throw new ArgumentException("Вычитание не может быть произведено, так как из меньшего вычитается большее.");

            return new Bundle(x.Banknote, x.Count - y.Count);
        }
    }
}
