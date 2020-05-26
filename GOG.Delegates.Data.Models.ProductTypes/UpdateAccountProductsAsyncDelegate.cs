using System.Collections.Generic;
using Attributes;
using GOG.Delegates.Conversions.Indexes.ProductTypes;
using GOG.Delegates.Conversions.ProductTypes;
using GOG.Delegates.Data.Storage.ProductTypes;
using GOG.Models;
using SecretSauce.Delegates.Confirmations.Interfaces;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Models;

namespace GOG.Delegates.Data.Models.ProductTypes
{
    public class UpdateAccountProductsAsyncDelegate : UpdateDataAsyncDelegate<AccountProduct>
    {
        [Dependencies(
            typeof(DeleteAccountProductsAsyncDelegate),
            typeof(ConvertAccountProductToIndexDelegate),
            typeof(GetStoredListAccountProductDataAsyncDelegate))]
        public UpdateAccountProductsAsyncDelegate(
            IDeleteAsyncDelegate<AccountProduct> deleteAccountProductsAsyncDelegate,
            IConvertDelegate<AccountProduct, long> convertAccountProductToIndexDelegate,
            IGetDataAsyncDelegate<List<AccountProduct>, string> getAccountProductsAsyncDelegate) :
            base(
                deleteAccountProductsAsyncDelegate,
                convertAccountProductToIndexDelegate,
                getAccountProductsAsyncDelegate)
        {
            // ...
        }
    }
}