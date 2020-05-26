using System;
using System.Collections.Generic;
using SecretSauce.Delegates.Collections.Interfaces;

namespace SecretSauce.Delegates.Collections
{
    public class MapDelegate<T> : IMapDelegate<T>
    {
        public void Map(IEnumerable<T> collection, Action<T> map)
        {
            if (collection == null) return;

            foreach (var item in collection)
                map(item);
        }
    }
}