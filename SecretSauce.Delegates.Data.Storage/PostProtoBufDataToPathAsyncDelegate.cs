using System.Threading.Tasks;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Data.Storage
{
    public abstract class PostProtoBufDataToPathAsyncDelegate<T> : IPostDataAsyncDelegate<T>
    {
        private readonly IGetValueDelegate<string, (string Directory, string Filename)> getPathDelegate;
        private readonly IPostDataAsyncDelegate<T> postProtoBufDataAsyncDelegate;

        public PostProtoBufDataToPathAsyncDelegate(
            IPostDataAsyncDelegate<T> postProtoBufDataAsyncDelegate,
            IGetValueDelegate<string, (string Directory, string Filename)> getPathDelegate)
        {
            this.postProtoBufDataAsyncDelegate = postProtoBufDataAsyncDelegate;
            this.getPathDelegate = getPathDelegate;
        }

        public async Task<string> PostDataAsync(T data, string uri = null)
        {
            return await postProtoBufDataAsyncDelegate.PostDataAsync(
                data,
                getPathDelegate.GetValue((string.Empty, uri)));
        }
    }
}