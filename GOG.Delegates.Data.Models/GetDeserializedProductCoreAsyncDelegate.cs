using System.Threading.Tasks;
using Models.ProductTypes;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;

namespace GOG.Delegates.Data.Models
{
    public abstract class GetDeserializedProductCoreAsyncDelegate<T> : IGetDataAsyncDelegate<T, string>
        where T : ProductCore
    {
        private readonly IConvertDelegate<string, T> convertJSONToProductCoreDelegate;
        private readonly IGetDataAsyncDelegate<string, string> getUriDataAsyncDelegate;

        public GetDeserializedProductCoreAsyncDelegate(
            IGetDataAsyncDelegate<string, string> getUriDataAsyncDelegate,
            IConvertDelegate<string, T> convertJSONToProductCoreDelegate)
        {
            this.getUriDataAsyncDelegate = getUriDataAsyncDelegate;
            this.convertJSONToProductCoreDelegate = convertJSONToProductCoreDelegate;
        }

        public async Task<T> GetDataAsync(string uri)
        {
            var response = await getUriDataAsyncDelegate.GetDataAsync(uri);

            if (response == null) return default;

            return convertJSONToProductCoreDelegate.Convert(response);
        }
    }
}