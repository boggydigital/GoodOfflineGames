using System.Collections.Generic;
using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Conversions.JSON.ProductTypes;
using SecretSauce.Delegates.Data.Interfaces;

namespace SecretSauce.Delegates.Data.Storage.ProductTypes
{
    public class GetListProductDownloadsDataAsyncDelegate : GetJSONDataAsyncDelegate<List<ProductDownloads>>
    {
        [Dependencies(
            typeof(GetStringDataAsyncDelegate),
            typeof(ConvertJSONToListProductDownloadsDelegate))]
        public GetListProductDownloadsDataAsyncDelegate(
            IGetDataAsyncDelegate<string, string> getStringDataAsyncDelegate,
            IConvertDelegate<string, List<ProductDownloads>> convertJSONToListProductDownloadsDelegate) :
            base(
                getStringDataAsyncDelegate,
                convertJSONToListProductDownloadsDelegate)
        {
            // ...
        }
    }
}