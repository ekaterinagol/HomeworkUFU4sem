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

        public void Add(object item) // использую фаткоризацию сделайте чттобы Lsp не нарушалось. а также изменить тест, чтобы подходил новой архитектуре
        {
            if (item is IMarked markedItem)
                storage.Push(markedItem); //проблема, что создавались новые штрих-коды а тут нет
            //else if (item is Product notMarkedItem)
            //{
                
            //    var newMarkedItem = new MarkedProduct(notMarkedItem.Name, notMarkedItem.Dimensions, notMarkedItem.Weight, new ulong());
            //    //IMarked barecode = newMarkedItem.Barcode();
            //    //var barecode = IMarked newMarkedItem;
            //    //storage.Push(newMarkedItem.Barcode);
        
            //}

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
