using System.Collections.Generic;
using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Values.Interfaces;
using SecretSauce.Delegates.Values.Paths.ProductTypes;

namespace SecretSauce.Delegates.Data.Storage.ProductTypes
{
    public class
        GetStoredListApiProductsRecordsDataAsyncDelegate : GetStoredJSONDataAsyncDelegate<List<ProductRecords>>
    {
        [Dependencies(
            typeof(GetListProductRecordsDataAsyncDelegate),
            typeof(GetApiProductsRecordsPathDelegate))]
        public GetStoredListApiProductsRecordsDataAsyncDelegate(
            IGetDataAsyncDelegate<List<ProductRecords>, string> getListProductRecordsDataAsyncDelegate,
            IGetValueDelegate<string, (string Directory, string Filename)> getApiProductsRecordsPathDelegate) :
            base(
                getListProductRecordsDataAsyncDelegate,
                getApiProductsRecordsPathDelegate)
        {
            // ...
        }
    }
}