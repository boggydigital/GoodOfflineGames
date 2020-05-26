using System.Collections.Generic;
using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Values.Interfaces;
using SecretSauce.Delegates.Values.Paths.ProductTypes;

namespace SecretSauce.Delegates.Data.Storage.ProductTypes
{
    public class
        GetStoredListProductDownloadsDataAsyncDelegate : GetStoredJSONDataAsyncDelegate<List<ProductDownloads>>
    {
        [Dependencies(
            typeof(GetListProductDownloadsDataAsyncDelegate),
            typeof(GetProductDownloadsPathDelegate))]
        public GetStoredListProductDownloadsDataAsyncDelegate(
            IGetDataAsyncDelegate<List<ProductDownloads>, string> getListProductDownloadsDataAsyncDelegate,
            IGetValueDelegate<string, (string Directory, string Filename)> getProductDownloadsPathDelegate) :
            base(
                getListProductDownloadsDataAsyncDelegate,
                getProductDownloadsPathDelegate)
        {
            // ...
        }
    }
}