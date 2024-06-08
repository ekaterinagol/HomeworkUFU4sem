using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse;

namespace Storage
{
    public class LimitedWarehouseWithMarkingAdapter : IStorage
    {
        LimitedWareHouseWithMarking storage;

        public LimitedWarehouseWithMarkingAdapter(LimitedWareHouseWithMarking warehouse)
        {
            storage = warehouse;
        }
        public void Add(object item)
        {
            if (item is IMarked markedItem)
                storage.Push(markedItem);

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
                storage.Delete(markedItem);
        }
    }
}
