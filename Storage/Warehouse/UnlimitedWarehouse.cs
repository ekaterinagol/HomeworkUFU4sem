using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    public class UnlimitedWarehouse
    {
        HashSet<Product> repository;

        public UnlimitedWarehouse()
        {
            repository = new HashSet<Product>();
        }

        public void ThrowIn(Product product)
        {
            repository.Add(product);
        }

        public void Utilize(Product product)
        {
            repository.Remove(product);
        }

        public bool IsIn(Product product)
        {
            return repository.Contains(product);
        }
    }
}
