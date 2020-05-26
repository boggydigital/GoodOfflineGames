using System.Collections.Generic;
using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Confirmations.Interfaces;
using SecretSauce.Delegates.Conversions.Indexes.ProductTypes;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Storage.ProductTypes;

namespace SecretSauce.Delegates.Data.Models.ProductTypes
{
    public class DeleteProductRoutesAsyncDelegate : DeleteAsyncDelegate<ProductRoutes>
    {
        [Dependencies(
            typeof(GetStoredListProductRoutesDataAsyncDelegate),
            typeof(ConvertProductRoutesToIndexDelegate))]
        public DeleteProductRoutesAsyncDelegate(
            IGetDataAsyncDelegate<List<ProductRoutes>, string> getDataCollectionAsyncDelegate,
            IConvertDelegate<ProductRoutes, long> convertProductToIndexDelegate) :
            base(
                getDataCollectionAsyncDelegate,
                convertProductToIndexDelegate)
        {
            // ...
        }
    }
}