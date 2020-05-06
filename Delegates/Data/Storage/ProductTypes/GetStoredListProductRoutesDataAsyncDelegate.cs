using System.Collections.Generic;
using Attributes;
using Delegates.Values.Paths.ProductTypes;
using Interfaces.Delegates.Data;
using Interfaces.Delegates.Values;
using Models.ProductTypes;

namespace Delegates.Data.Storage.ProductTypes
{
    public class GetStoredListProductRoutesDataAsyncDelegate : GetStoredJSONDataAsyncDelegate<List<ProductRoutes>>
    {
        [Dependencies(
            typeof(GetListProductRoutesDataAsyncDelegate),
            typeof(GetProductRoutesPathDelegate))]
        public GetStoredListProductRoutesDataAsyncDelegate(
            IGetDataAsyncDelegate<List<ProductRoutes>, string> getListProductRoutesDataAsyncDelegate,
            IGetValueDelegate<string,(string Directory,string Filename)> getProductRoutesPathDelegate) :
            base(
                getListProductRoutesDataAsyncDelegate,
                getProductRoutesPathDelegate)
        {
            // ...
        }
    }
}