using System.Collections.Generic;
using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Values.Interfaces;
using SecretSauce.Delegates.Values.Paths.ProductTypes;

namespace SecretSauce.Delegates.Data.Storage.ProductTypes
{
    public class
        GetStoredListGameDetailsRecordsDataAsyncDelegate : GetStoredJSONDataAsyncDelegate<List<ProductRecords>>
    {
        [Dependencies(
            typeof(GetListProductRecordsDataAsyncDelegate),
            typeof(GetGameDetailsRecordsPathDelegate))]
        public GetStoredListGameDetailsRecordsDataAsyncDelegate(
            IGetDataAsyncDelegate<List<ProductRecords>, string> getListProductRecordsDataAsyncDelegate,
            IGetValueDelegate<string, (string Directory, string Filename)> getGameDetailsRecordsPathDelegate) :
            base(
                getListProductRecordsDataAsyncDelegate,
                getGameDetailsRecordsPathDelegate)
        {
            // ...
        }
    }
}