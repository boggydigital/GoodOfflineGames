using System.Collections.Generic;
using Attributes;
using GOG.Delegates.Collections.ProductTypes;
using GOG.Delegates.Conversions.Indexes.ProductTypes;
using GOG.Delegates.Data.Storage.ProductTypes;
using GOG.Models;
using SecretSauce.Delegates.Collections.Interfaces;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Models;

namespace GOG.Delegates.Data.Models.ProductTypes
{
    public class GetAccountProductByIdAsyncDelegate : GetDataByIdAsyncDelegate<AccountProduct>
    {
        [Dependencies(
            typeof(GetStoredListAccountProductDataAsyncDelegate),
            typeof(FindAccountProductDelegate),
            typeof(ConvertAccountProductToIndexDelegate))]
        public GetAccountProductByIdAsyncDelegate(
            IGetDataAsyncDelegate<List<AccountProduct>, string> getListAccountProductsAsyncDelegate,
            IFindDelegate<AccountProduct> findDelegate,
            IConvertDelegate<AccountProduct, long> convertProductToIndexDelegate) :
            base(
                getListAccountProductsAsyncDelegate,
                findDelegate,
                convertProductToIndexDelegate)
        {
            // ...
        }
    }
}