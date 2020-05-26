using System.Collections.Generic;
using Attributes;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Values.Interfaces;
using SecretSauce.Delegates.Values.Paths.ProductTypes;

namespace SecretSauce.Delegates.Data.Storage.ProductTypes
{
    public class GetStoredListUpdatedDataAsyncDelegate : GetStoredJSONDataAsyncDelegate<List<long>>
    {
        [Dependencies(
            typeof(GetListUpdatedDataAsyncDelegate),
            typeof(GetUpdatedPathDelegate))]
        public GetStoredListUpdatedDataAsyncDelegate(
            IGetDataAsyncDelegate<List<long>, string> getListUpdatedDataAsyncDelegate,
            IGetValueDelegate<string, (string Directory, string Filename)> getUpdatedPathDelegate) :
            base(
                getListUpdatedDataAsyncDelegate,
                getUpdatedPathDelegate)
        {
            // ...
        }
    }
}