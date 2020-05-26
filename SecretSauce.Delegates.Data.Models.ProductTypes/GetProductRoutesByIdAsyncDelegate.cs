using System.Collections.Generic;
using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Collections.Interfaces;
using SecretSauce.Delegates.Conversions.Indexes.ProductTypes;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Storage.ProductTypes;

namespace SecretSauce.Delegates.Data.Models.ProductTypes
{
    public class GetProductRoutesByIdAsyncDelegate :
        GetDataByIdAsyncDelegate<ProductRoutes>
    {
        [Dependencies(
            typeof(GetStoredListProductRoutesDataAsyncDelegate),
            typeof(Delegates.Collections.ProductTypes.FindProductRoutesDelegate),
            typeof(ConvertProductRoutesToIndexDelegate))]
        public GetProductRoutesByIdAsyncDelegate(
            IGetDataAsyncDelegate<List<ProductRoutes>, string> getDataCollectionAsyncDelegate,
            IFindDelegate<ProductRoutes> findDelegate,
            IConvertDelegate<ProductRoutes, long> convertProductToIndexDelegate) :
            base(
                getDataCollectionAsyncDelegate,
                findDelegate,
                convertProductToIndexDelegate)
        {
            // ...
        }
    }
}