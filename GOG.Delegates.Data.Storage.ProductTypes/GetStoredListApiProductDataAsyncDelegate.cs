using System.Collections.Generic;
using Attributes;
using GOG.Models;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Storage;
using SecretSauce.Delegates.Values.Interfaces;
using SecretSauce.Delegates.Values.Paths.ProductTypes;

namespace GOG.Delegates.Data.Storage.ProductTypes
{
    public class GetStoredListApiProductDataAsyncDelegate : GetStoredJSONDataAsyncDelegate<List<ApiProduct>>
    {
        [Dependencies(
            typeof(GetListApiProductDataAsyncDelegate),
            typeof(GetApiProductsPathDelegate))]
        public GetStoredListApiProductDataAsyncDelegate(
            IGetDataAsyncDelegate<List<ApiProduct>, string> getListApiProductDataAsyncDelegate,
            IGetValueDelegate<string, (string Directory, string Filename)> getApiProductsPathDelegate) :
            base(
                getListApiProductDataAsyncDelegate,
                getApiProductsPathDelegate)
        {
            // ...
        }
    }
}