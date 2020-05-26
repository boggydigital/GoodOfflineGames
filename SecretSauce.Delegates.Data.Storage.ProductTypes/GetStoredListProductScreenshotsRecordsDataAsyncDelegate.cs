using System.Collections.Generic;
using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Values.Interfaces;
using SecretSauce.Delegates.Values.Paths.ProductTypes;

namespace SecretSauce.Delegates.Data.Storage.ProductTypes
{
    public class
        GetStoredListProductScreenshotsRecordsDataAsyncDelegate : GetStoredJSONDataAsyncDelegate<
            List<ProductRecords>>
    {
        [Dependencies(
            typeof(GetListProductRecordsDataAsyncDelegate),
            typeof(GetProductScreenshotsRecordsPathDelegate))]
        public GetStoredListProductScreenshotsRecordsDataAsyncDelegate(
            IGetDataAsyncDelegate<List<ProductRecords>, string> getListProductRecordsDataAsyncDelegate,
            IGetValueDelegate<string, (string Directory, string Filename)> getProductScreenshotsRecordsPathDelegate) :
            base(
                getListProductRecordsDataAsyncDelegate,
                getProductScreenshotsRecordsPathDelegate)
        {
            // ...
        }
    }
}