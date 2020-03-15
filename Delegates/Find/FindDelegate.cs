using System;
using System.Collections.Generic;

using Interfaces.Delegates.Find;

namespace Delegates.Find
{
    public abstract class FindDelegate<T> : IFindDelegate<T>
    {
        private IFindAllDelegate<T> findAllDelegate;

        public FindDelegate(IFindAllDelegate<T> findAllDelegate)
        {
            this.findAllDelegate = findAllDelegate;
        }

        public T Find(IEnumerable<T> collection, Predicate<T> find)
        {
            foreach (var item in findAllDelegate.FindAll(collection, find))
                return item;

            return default(T);
        }
    }
}