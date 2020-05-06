using System.Threading.Tasks;
using Interfaces.Delegates.Data;
using Interfaces.Delegates.Values;

namespace Delegates.Data.Storage
{
    public abstract class GetStoredJSONDataAsyncDelegate<T> : IGetDataAsyncDelegate<T, string>
        where T : new()
    {
        private readonly IGetDataAsyncDelegate<T, string> getJSONDataAsyncDelegate;
        private readonly IGetValueDelegate<string, (string Directory, string Filename)> getPathDelegate;
        private T storedData;

        public GetStoredJSONDataAsyncDelegate(
            IGetDataAsyncDelegate<T, string> getJSONDataAsyncDelegate,
            IGetValueDelegate<string, (string Directory, string Filename)> getPathDelegate)
        {
            this.getJSONDataAsyncDelegate = getJSONDataAsyncDelegate;
            this.getPathDelegate = getPathDelegate;
        }

        public async Task<T> GetDataAsync(string uri = null)
        {
            if (storedData == null)
                storedData = await getJSONDataAsyncDelegate.GetDataAsync(
                                 getPathDelegate.GetValue((string.Empty, uri)))
                             ?? new T();
            return storedData;
        }
    }
}