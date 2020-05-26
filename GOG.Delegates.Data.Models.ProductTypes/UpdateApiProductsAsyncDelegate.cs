using System.Collections.Generic;
using Attributes;
using GOG.Delegates.Conversions.Indexes.ProductTypes;
using GOG.Delegates.Data.Storage.ProductTypes;
using GOG.Models;
using SecretSauce.Delegates.Confirmations.Interfaces;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Models;

namespace GOG.Delegates.Data.Models.ProductTypes
{
    public class UpdateApiProductsAsyncDelegate : UpdateDataAsyncDelegate<ApiProduct>
    {
        [Dependencies(
            typeof(DeleteApiProductsAsyncDelegate),
            typeof(ConvertApiProductToIndexDelegate),
            typeof(GetStoredListApiProductDataAsyncDelegate))]
        public UpdateApiProductsAsyncDelegate(
            IDeleteAsyncDelegate<ApiProduct> deleteApiProductsAsyncDelegate,
            IConvertDelegate<ApiProduct, long> convertApiProductToIndexDelegate,
            IGetDataAsyncDelegate<List<ApiProduct>, string> getApiProductsAsyncDelegate) :
            base(
                deleteApiProductsAsyncDelegate,
                convertApiProductToIndexDelegate,
                getApiProductsAsyncDelegate)
        {
            // ...
        }
    }
}