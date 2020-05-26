using System.Collections.Generic;
using Attributes;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Values.Interfaces;
using SecretSauce.Delegates.Values.Paths.ProductTypes;

namespace SecretSauce.Delegates.Data.Storage.ProductTypes
{
    public class GetStoredListWishlistedDataAsyncDelegate : GetStoredJSONDataAsyncDelegate<List<long>>
    {
        [Dependencies(
            typeof(GetListWishlistedDataAsyncDelegate),
            typeof(GetWishlistedPathDelegate))]
        public GetStoredListWishlistedDataAsyncDelegate(
            IGetDataAsyncDelegate<List<long>, string> getListWishlistedDataAsyncDelegate,
            IGetValueDelegate<string, (string Directory, string Filename)> getWishlistedPathDelegate) :
            base(
                getListWishlistedDataAsyncDelegate,
                getWishlistedPathDelegate)
        {
            // ...
        }
    }
}