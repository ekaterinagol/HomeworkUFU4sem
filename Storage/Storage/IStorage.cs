using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public interface IStorage
    {
        void Add(object item);
        void Remove(object item);
        bool Contains(object item);
    }
}
