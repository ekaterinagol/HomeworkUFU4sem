using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse;

namespace Storage
{
    public class LimitedWarehouseAdapter : IStorage
    {
        LimitedWarehouse storage;

        public LimitedWarehouseAdapter(LimitedWarehouse warehouse)
        {
            storage = warehouse;
        }
        public void Add(object item)
        {
            if (item is Product product)
                storage.Place(product);
        }

        public bool Contains(object item)
        {
            if (item is Product product)
                return storage.IsHere(product);

            return false;
        }

        public void Remove(object item)
        {
            if (item is Product product)
                storage.Eliminate(product);
        }
    }
}
