﻿using System;
using System.Collections.Generic;

namespace Interfaces.Collection
{
    //public interface ICollectionContainer<T>
    //{
    //    IList<T> Collection { get; }
    //}

    public interface IAddDelegate<T>
    {
        void Add(T item);
    }

    //public interface IUpdateOrAddDelegate<T>
    //{
    //    void UpdateOrAdd(T item);
    //}

    public interface IInsertDelegate<T>
    {
        void Insert(int index, T item);
    }

    public interface IRemoveDelegate<T>
    {
        bool Remove(T item);
    }

    public interface IContainsDelegate<T>
    {
        bool Contains(T item);
    }

    public interface IMapDelegate<T>
    {
        void Map(Predicate<T> action);
    }

    public interface IReduceDelegate<T>
    {
        IEnumerable<T> Reduce(Predicate<T> condition);
    }

    public interface IFindDelegate<T>
    {
        T Find(Predicate<T> input);
    }

    //public interface IFindCollectionDelegate<Input, Result>
    //{
    //    IEnumerable<Result> Find(IEnumerable<Input> input);
    //}

    public interface ICollectionController<T>:
        //ICollectionContainer<T>,
        IContainsDelegate<T>,
        IAddDelegate<T>,
        //IUpdateOrAddDelegate<T>,
        IInsertDelegate<T>,
        IRemoveDelegate<T>,
        IMapDelegate<T>,
        IReduceDelegate<T>,
        IFindDelegate<T>
    {
        // ...
    }
}
