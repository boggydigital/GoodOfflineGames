using System.Collections.Generic;
using Attributes;
using GOG.Delegates.Conversions.JSON;
using GOG.Models;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Storage;

namespace GOG.Delegates.Data.Storage.ProductTypes
{
    public class GetListProductDataAsyncDelegate : GetJSONDataAsyncDelegate<List<Product>>
    {
        [Dependencies(
            typeof(GetStringDataAsyncDelegate),
            typeof(ConvertJSONToListProductDelegate))]
        public GetListProductDataAsyncDelegate(
            IGetDataAsyncDelegate<string, string> getStringDataAsyncDelegate,
            IConvertDelegate<string, List<Product>> convertJSONToListProductDelegate) :
            base(
                getStringDataAsyncDelegate,
                convertJSONToListProductDelegate)
        {
            // ...
        }
    }
}