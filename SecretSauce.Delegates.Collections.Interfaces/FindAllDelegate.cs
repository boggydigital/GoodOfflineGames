using System;
using System.Collections.Generic;

namespace SecretSauce.Delegates.Collections.Interfaces
{
    public interface IFindAllDelegate<T>
    {
        IEnumerable<T> FindAll(IEnumerable<T> collection, Predicate<T> condition);
    }
}