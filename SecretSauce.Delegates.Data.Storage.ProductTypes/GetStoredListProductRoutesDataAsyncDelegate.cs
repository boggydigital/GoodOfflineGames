using System.Collections.Generic;
using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Values.Interfaces;
using SecretSauce.Delegates.Values.Paths.ProductTypes;

namespace SecretSauce.Delegates.Data.Storage.ProductTypes
{
    public class GetStoredListProductRoutesDataAsyncDelegate : GetStoredJSONDataAsyncDelegate<List<ProductRoutes>>
    {
        [Dependencies(
            typeof(GetListProductRoutesDataAsyncDelegate),
            typeof(GetProductRoutesPathDelegate))]
        public GetStoredListProductRoutesDataAsyncDelegate(
            IGetDataAsyncDelegate<List<ProductRoutes>, string> getListProductRoutesDataAsyncDelegate,
            IGetValueDelegate<string, (string Directory, string Filename)> getProductRoutesPathDelegate) :
            base(
                getListProductRoutesDataAsyncDelegate,
                getProductRoutesPathDelegate)
        {
            // ...
        }
    }
}