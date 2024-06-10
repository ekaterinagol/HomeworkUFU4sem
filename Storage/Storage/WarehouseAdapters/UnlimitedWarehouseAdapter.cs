using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse;

namespace Storage.WarehouseAdapters
{
    public class UnlimitedWarehouseAdapter : IStorage
    {
        UnlimitedWarehouse storage;

        public UnlimitedWarehouseAdapter(UnlimitedWarehouse warehouse)
        {
            storage = warehouse;
        }

        public void Add(object item)
        {
            if (item is Product product)
                storage.ThrowIn(product);
        }

        public bool Contains(object item)
        {
            if (item is Product product)
                return storage.IsIn(product);

            return false;
        }

        public void Remove(object item)
        {
            if (item is Product product)
                storage.Utilize(product);
        }
    }
}
