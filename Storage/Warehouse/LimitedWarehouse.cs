using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    public class LimitedWarehouse
    {
        (Product, DateTime)[] repository;
        int index;

        public LimitedWarehouse(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException("Вместимость склада должна быть положительной");

            repository = new (Product, DateTime)[capacity];
            index = 0;
        }

        public bool IsHere(Product product)
        {
            return repository
                .Select(z => z.Item1)
                .Where(z => z == product)
                .Count() > 0;
        }
        public void Place(Product product)
        {
            if (IsHere(product))
                return;

            if (index < repository.Length)
                repository[index++] = (product, DateTime.Now);
            else
            {
                int minIndex = -1;
                var minTime = DateTime.MaxValue;
                for(var i = 0; i < repository.Length; i++)
                {
                    var t = repository[i].Item2;
                    if (t < minTime)
                    {
                        minTime = t;
                        minIndex = i;
                    }
                }

                repository[minIndex] = (product, DateTime.Now);
            }
        }

        public void Eliminate(Product product)
        {

            int productIndex = -1;

            for(var i = 0; i < repository.Length; i++)
                if(repository[i].Item1 == product)
                {
                    productIndex = i;
                    break;
                }

            if (productIndex < 0)
                return;

            for (var i = productIndex + 1; i < repository.Length; i++)
                repository[i - 1] = repository[i];

            index--;
        }

    }
}
