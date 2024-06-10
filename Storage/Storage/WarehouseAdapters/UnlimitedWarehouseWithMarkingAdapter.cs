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

        public UnlimitedWarehouseWithMarkingAdapter(UnlimitedWarehouseWithMarking warehouse)
        {
            storage = warehouse;
        }

        public void Add(object item)
        {
            if (item is IMarked markedItem)
                storage.Put(markedItem);
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
