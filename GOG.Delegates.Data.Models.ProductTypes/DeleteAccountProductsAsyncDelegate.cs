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
    public class DeleteAccountProductsAsyncDelegate : DeleteAsyncDelegate<AccountProduct>
    {
        [Dependencies(
            typeof(GetStoredListAccountProductDataAsyncDelegate),
            typeof(ConvertAccountProductToIndexDelegate))]
        public DeleteAccountProductsAsyncDelegate(
            IGetDataAsyncDelegate<List<AccountProduct>, string> getDataCollectionAsyncDelegate,
            IConvertDelegate<AccountProduct, long> convertProductToIndexDelegate,
            IConfirmAsyncDelegate<long> confirmContainsAsyncDelegate) :
            base(
                getDataCollectionAsyncDelegate,
                convertProductToIndexDelegate)
        {
            // ...
        }
    }
}