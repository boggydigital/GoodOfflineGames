using System.Threading.Tasks;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Data.Storage
{
    public abstract class GetProtoBufDataFromPathAsyncDelegate<T> : IGetDataAsyncDelegate<T, string>
    {
        private readonly IGetValueDelegate<string, (string Directory, string Filename)> getPathDelegate;
        private readonly IGetDataAsyncDelegate<T, string> getProtoBufDataAsyncDelegate;

        public GetProtoBufDataFromPathAsyncDelegate(
            IGetDataAsyncDelegate<T, string> getProtoBufDataAsyncDelegate,
            IGetValueDelegate<string, (string Directory, string Filename)> getPathDelegate)
        {
            this.getProtoBufDataAsyncDelegate = getProtoBufDataAsyncDelegate;
            this.getPathDelegate = getPathDelegate;
        }

        public async Task<T> GetDataAsync(string uri = null)
        {
            return await getProtoBufDataAsyncDelegate.GetDataAsync(
                getPathDelegate.GetValue((string.Empty, uri)));
        }
    }
}