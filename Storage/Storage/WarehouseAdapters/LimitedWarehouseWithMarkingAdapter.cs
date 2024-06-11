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
        ulong barecode;

        public LimitedWarehouseWithMarkingAdapter(LimitedWareHouseWithMarking warehouse)
        {
            storage = warehouse;
        }

        public void Add(object item) // использую фаткоризацию сделайте чттобы Lsp не нарушалось. а также изменить тест, чтобы подходил новой архитектуре
        {
            if (item is IMarked markedItem)
                storage.Push(markedItem); //проблема, подается не IMarked и не создается новый штрих-код
            else if (item is Product notMarkedItem)
            {
                barecode = 1111111111111;
                storage.Push(new MarkedProduct(notMarkedItem.Name, notMarkedItem.Dimensions, notMarkedItem.Weight, barecode));
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
                storage.Delete(markedItem);
        }
    }
}
