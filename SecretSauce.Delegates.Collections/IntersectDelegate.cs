using System.Collections.Generic;
using SecretSauce.Delegates.Collections.Interfaces;

namespace SecretSauce.Delegates.Collections
{
    public class IntersectDelegate<T> : IIntersectDelegate<T>
    {
        private readonly IFindAllDelegate<T> findAllDelegate;
        private readonly IFindDelegate<T> findDelegate;

        public IntersectDelegate(
            IFindAllDelegate<T> findAllDelegate,
            IFindDelegate<T> findDelegate)
        {
            this.findAllDelegate = findAllDelegate;
            this.findDelegate = findDelegate;
        }

        public IEnumerable<T> Intersect(IEnumerable<T> firstCollection, IEnumerable<T> secondCollection)
        {
            return findAllDelegate.FindAll(
                firstCollection,
                firstItem => findDelegate.Find(
                    secondCollection,
                    secondItem => secondItem.Equals(firstItem)) != null);
        }
    }
}