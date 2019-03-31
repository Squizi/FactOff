using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactOff.Factories
{
    interface IFactory<T>
    {
        T GetInstance(int id, params object[] args);
    }
}
