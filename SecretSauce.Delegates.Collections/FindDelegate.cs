using System;
using System.Collections.Generic;
using SecretSauce.Delegates.Collections.Interfaces;

namespace SecretSauce.Delegates.Collections
{
    public class FindDelegate<T> : IFindDelegate<T>
    {
        private readonly IFindAllDelegate<T> findAllDelegate;

        public FindDelegate(IFindAllDelegate<T> findAllDelegate)
        {
            this.findAllDelegate = findAllDelegate;
        }

        public T Find(IEnumerable<T> collection, Predicate<T> find)
        {
            foreach (var item in findAllDelegate.FindAll(collection, find))
                return item;

            return default;
        }
    }
}