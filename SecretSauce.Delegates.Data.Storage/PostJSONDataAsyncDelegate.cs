using System.Threading.Tasks;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;

namespace SecretSauce.Delegates.Data.Storage
{
    public abstract class PostJSONDataAsyncDelegate<T> : IPostDataAsyncDelegate<T>
    {
        private readonly IConvertDelegate<T, string> convertTypeToJSONDelegate;
        private readonly IPostDataAsyncDelegate<string> postStringDataAsyncDelegate;

        public PostJSONDataAsyncDelegate(
            IPostDataAsyncDelegate<string> postStringDataAsyncDelegate,
            IConvertDelegate<T, string> convertTypeToJSONDelegate)
        {
            this.postStringDataAsyncDelegate = postStringDataAsyncDelegate;
            this.convertTypeToJSONDelegate = convertTypeToJSONDelegate;
        }

        public async Task<string> PostDataAsync(T data, string uri = null)
        {
            var serializedData = convertTypeToJSONDelegate.Convert(data);
            return await postStringDataAsyncDelegate.PostDataAsync(serializedData, uri);
        }
    }
}