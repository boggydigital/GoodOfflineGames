using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecretSauce.Delegates.Collections.Interfaces
{
    public interface ISortAsyncDelegate<T>
    {
        Task SortAsync(List<T> collection);
    }
}