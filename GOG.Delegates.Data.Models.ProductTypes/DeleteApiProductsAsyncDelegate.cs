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
    public class DeleteApiProductsAsyncDelegate : DeleteAsyncDelegate<ApiProduct>
    {
        [Dependencies(
            typeof(GetStoredListApiProductDataAsyncDelegate),
            typeof(ConvertApiProductToIndexDelegate))]
        public DeleteApiProductsAsyncDelegate(
            IGetDataAsyncDelegate<List<ApiProduct>, string> getDataCollectionAsyncDelegate,
            IConvertDelegate<ApiProduct, long> convertProductToIndexDelegate,
            IConfirmAsyncDelegate<long> confirmContainsAsyncDelegate) :
            base(
                getDataCollectionAsyncDelegate,
                convertProductToIndexDelegate)
        {
            // ...
        }
    }
}