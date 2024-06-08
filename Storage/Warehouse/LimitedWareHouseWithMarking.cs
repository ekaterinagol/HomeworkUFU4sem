using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    public class LimitedWareHouseWithMarking
    {
        Dictionary<ulong, HashSet<(IMarked, DateTime)>> repository;
        int capacity;

        public LimitedWareHouseWithMarking(int capacity)
        {
            this.capacity = capacity;

            if (capacity <= 0)
                throw new ArgumentException("Вместимость склада должна быть положительной");

            repository = new Dictionary<ulong, HashSet<(IMarked, DateTime)>>();
        }

        public void Push(IMarked unit)
        {
            if (IsKeep(unit))
                return;

            if (repository.Count() == capacity)
            {
                var units = GetAll();

                var minTime = units.Min(z => z.Item2);

                var pairToDelete = units
                    .Where(z => z.Item2 == minTime)
                    .FirstOrDefault();

                repository[pairToDelete.Item1.Barcode].Remove(pairToDelete);
            }

            if(repository.ContainsKey(unit.Barcode))
                repository[unit.Barcode].Add((unit, DateTime.Now));
            else
            {
                repository[unit.Barcode] = new HashSet<(IMarked, DateTime)>(new[] { (unit, DateTime.Now)});
            }
        }

        public void Delete(IMarked unit)
        {
            if (!IsKeep(unit))
                return;

            var units = GetAll();

            var pairToDelete = units
                .Where(z => z.Item1 == unit)
                .FirstOrDefault();

            repository[unit.Barcode].Remove(pairToDelete);
        }

        public bool IsKeep(IMarked unit)
        {
            return repository.ContainsKey(unit.Barcode)
                && repository[unit.Barcode].Any(x => x.Item1 == unit);
        }

        IEnumerable<(IMarked, DateTime)> GetAll()
        {
            return repository
                    .Select(z => z.Value)
                    .SelectMany(z => z);
        }
    }
}
