using System;
using System.Collections.Generic;

namespace SecretSauce.Delegates.Collections.Interfaces
{
    public interface IFindDelegate<T>
    {
        T Find(IEnumerable<T> collection, Predicate<T> find);
    }
}