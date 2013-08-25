using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactManager
{
    public interface IRepository<T>
    {
        void Add(Contact c);
    }
}
