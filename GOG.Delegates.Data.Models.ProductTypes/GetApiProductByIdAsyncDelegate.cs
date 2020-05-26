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
    public class GetApiProductByIdAsyncDelegate : GetDataByIdAsyncDelegate<ApiProduct>
    {
        [Dependencies(
            typeof(GetStoredListApiProductDataAsyncDelegate),
            typeof(FindApiProductDelegate),
            typeof(ConvertApiProductToIndexDelegate))]
        public GetApiProductByIdAsyncDelegate(
            IGetDataAsyncDelegate<List<ApiProduct>, string> getListApiProductsAsyncDelegate,
            IFindDelegate<ApiProduct> findDelegate,
            IConvertDelegate<ApiProduct, long> convertApiProductToIndexDelegate) :
            base(
                getListApiProductsAsyncDelegate,
                findDelegate,
                convertApiProductToIndexDelegate)
        {
            // ...
        }
    }
}