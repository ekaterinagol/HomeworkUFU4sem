using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    public class UnlimitedWarehouseWithMarking
    {
        Dictionary<ulong, HashSet<IMarked>> repository;

        public UnlimitedWarehouseWithMarking()
        {
            repository = new Dictionary<ulong, HashSet<IMarked>>();
        }

        public void Put(IMarked unit)
        {
            if (repository.ContainsKey(unit.Barcode))
                repository[unit.Barcode].Add(unit);
            else
                repository[unit.Barcode] = new HashSet<IMarked>(new[] { unit });
        }

        public void Drop(IMarked unit)
        {
            if (repository.ContainsKey(unit.Barcode)
                && repository[unit.Barcode].Contains(unit))
            {
                repository[unit.Barcode].Remove(unit);

                if (repository[unit.Barcode].Count() == 0)
                    repository.Remove(unit.Barcode);
            }
        }

        public bool IsKeep(IMarked unit)
        {
            return repository.ContainsKey(unit.Barcode)
                && repository[unit.Barcode].Contains(unit);
        }
    }
}
