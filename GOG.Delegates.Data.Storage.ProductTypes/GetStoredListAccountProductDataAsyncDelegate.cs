using System.Collections.Generic;
using Attributes;
using GOG.Models;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Storage;
using SecretSauce.Delegates.Values.Interfaces;
using SecretSauce.Delegates.Values.Paths.ProductTypes;

namespace GOG.Delegates.Data.Storage.ProductTypes
{
    public class GetStoredListAccountProductDataAsyncDelegate : GetStoredJSONDataAsyncDelegate<List<AccountProduct>>
    {
        [Dependencies(
            typeof(GetListAccountProductDataAsyncDelegate),
            typeof(GetAccountProductsPathDelegate))]
        public GetStoredListAccountProductDataAsyncDelegate(
            IGetDataAsyncDelegate<List<AccountProduct>, string> getListAccountProductDataAsyncDelegate,
            IGetValueDelegate<string, (string Directory, string Filename)> getAccountProductsPathDelegate) :
            base(
                getListAccountProductDataAsyncDelegate,
                getAccountProductsPathDelegate)
        {
            // ...
        }
    }
}