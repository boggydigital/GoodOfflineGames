using System.Threading.Tasks;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Data.Storage
{
    public abstract class PostJSONDataToPathAsyncDelegate<T> : IPostDataAsyncDelegate<T>
    {
        private readonly IGetValueDelegate<string, (string Directory, string Filename)> getPathDelegate;
        private readonly IPostDataAsyncDelegate<T> postJSONDataAsyncDelegate;

        public PostJSONDataToPathAsyncDelegate(
            IPostDataAsyncDelegate<T> postJSONDataAsyncDelegate,
            IGetValueDelegate<string, (string Directory, string Filename)> getPathDelegate)
        {
            this.postJSONDataAsyncDelegate = postJSONDataAsyncDelegate;
            this.getPathDelegate = getPathDelegate;
        }

        public async Task<string> PostDataAsync(T data, string uri = null)
        {
            return await postJSONDataAsyncDelegate.PostDataAsync(
                data,
                getPathDelegate.GetValue((string.Empty, uri)));
        }
    }
}