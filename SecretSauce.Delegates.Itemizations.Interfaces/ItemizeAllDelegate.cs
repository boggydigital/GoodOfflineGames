using System.Collections.Generic;

namespace SecretSauce.Delegates.Itemizations.Interfaces
{
    public interface IItemizeAllAsyncDelegate<Output>
    {
        IAsyncEnumerable<Output> ItemizeAllAsync();
    }

    public interface IItemizeAllDelegate<Output>
    {
        IEnumerable<Output> ItemizeAll();
    }
}