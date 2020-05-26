using System.Collections.Generic;

namespace SecretSauce.Delegates.Collections.Interfaces
{
    public interface IIntersectDelegate<T>
    {
        IEnumerable<T> Intersect(IEnumerable<T> firstCollection, IEnumerable<T> secondCollection);
    }
}