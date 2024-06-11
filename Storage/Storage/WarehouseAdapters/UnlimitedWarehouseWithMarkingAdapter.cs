using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse;

namespace Storage.WarehouseAdapters
{
    public class UnlimitedWarehouseWithMarkingAdapter : IStorage
    {
        UnlimitedWarehouseWithMarking storage;
        ulong barecode;

        public UnlimitedWarehouseWithMarkingAdapter(UnlimitedWarehouseWithMarking warehouse)
        {
            storage = warehouse;
        }

        public void Add(object item)
        {
            if (item is IMarked markedItem)
                storage.Put(markedItem);
            else if (item is Product notMarkedItem)
            {
                barecode = 1111111111111;
                storage.Put(new MarkedProduct(notMarkedItem.Name, notMarkedItem.Dimensions, notMarkedItem.Weight, barecode));
            }
        }

        public bool Contains(object item)
        {
            if (item is IMarked markedItem)
                return storage.IsKeep(markedItem);

            return false;
        }

        public void Remove(object item)
        {
            if (item is IMarked markedItem)
                storage.Drop(markedItem);
        }
    }
}
