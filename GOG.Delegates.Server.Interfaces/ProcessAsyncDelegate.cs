using System.Collections.Generic;
using System.Threading.Tasks;

namespace GOG.Delegates.Server.Interfaces
{
    public interface IProcessAsyncDelegate
    {
        Task ProcessAsync(IDictionary<string, IEnumerable<string>> parameters);
    }
}