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
    public class UpdateProductRoutesAsyncDelegate : UpdateDataAsyncDelegate<ProductRoutes>
    {
        [Dependencies(
            typeof(DeleteProductRoutesAsyncDelegate),
            typeof(ConvertProductRoutesToIndexDelegate),
            typeof(GetStoredListProductRoutesDataAsyncDelegate))]
        public UpdateProductRoutesAsyncDelegate(
            IDeleteAsyncDelegate<ProductRoutes> deleteAsyncDelegate,
            IConvertDelegate<ProductRoutes, long> convertProductToIndexDelegate,
            IGetDataAsyncDelegate<List<ProductRoutes>, string> getListProductRoutesAsyncDelegate) :
            base(
                deleteAsyncDelegate,
                convertProductToIndexDelegate,
                getListProductRoutesAsyncDelegate)
        {
            // ...
        }
    }
}