using System.Threading.Tasks;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;

namespace SecretSauce.Delegates.Data.Storage
{
    public abstract class GetJSONDataAsyncDelegate<T> : IGetDataAsyncDelegate<T, string>
    {
        private readonly IConvertDelegate<string, T> convertJSONToTypeDelegate;
        private readonly IGetDataAsyncDelegate<string, string> getStringDataAsyncDelegate;
        private T data;

        public GetJSONDataAsyncDelegate(
            IGetDataAsyncDelegate<string, string> getStringDataAsyncDelegate,
            IConvertDelegate<string, T> convertJSONToTypeDelegate)
        {
            this.getStringDataAsyncDelegate = getStringDataAsyncDelegate;
            this.convertJSONToTypeDelegate = convertJSONToTypeDelegate;
        }

        public async Task<T> GetDataAsync(string uri = null)
        {
            if (data == null)
            {
                var serializedData = await getStringDataAsyncDelegate.GetDataAsync(uri);
                data = convertJSONToTypeDelegate.Convert(serializedData);
            }

            return data;
        }
    }
}