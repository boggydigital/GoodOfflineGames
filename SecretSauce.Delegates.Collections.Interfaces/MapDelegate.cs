using System;
using System.Collections.Generic;

namespace SecretSauce.Delegates.Collections.Interfaces
{
    public interface IMapDelegate<T>
    {
        void Map(IEnumerable<T> collection, Action<T> map);
    }
}