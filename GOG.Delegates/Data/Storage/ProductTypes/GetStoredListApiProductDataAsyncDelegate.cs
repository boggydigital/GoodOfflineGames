using System.Collections.Generic;
using Attributes;
using Delegates.Data.Storage;
using Delegates.Values.Paths.ProductTypes;
using Interfaces.Delegates.Data;
using Interfaces.Delegates.Values;
using GOG.Models;

namespace GOG.Delegates.Data.Storage.ProductTypes
{
    public class GetStoredListApiProductDataAsyncDelegate : GetStoredJSONDataAsyncDelegate<List<ApiProduct>>
    {
        [Dependencies(
            typeof(GetListApiProductDataAsyncDelegate),
            typeof(GetApiProductsPathDelegate))]
        public GetStoredListApiProductDataAsyncDelegate(
            IGetDataAsyncDelegate<List<ApiProduct>,string> getListApiProductDataAsyncDelegate,
            IGetValueDelegate<string,(string Directory,string Filename)> getApiProductsPathDelegate) :
            base(
                getListApiProductDataAsyncDelegate,
                getApiProductsPathDelegate)
        {
            // ...
        }
    }
}