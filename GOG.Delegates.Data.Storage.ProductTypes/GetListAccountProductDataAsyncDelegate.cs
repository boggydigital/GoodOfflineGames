using System.Collections.Generic;
using Attributes;
using GOG.Delegates.Conversions.JSON;
using GOG.Models;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Storage;

namespace GOG.Delegates.Data.Storage.ProductTypes
{
    public class GetListAccountProductDataAsyncDelegate : GetJSONDataAsyncDelegate<List<AccountProduct>>
    {
        [Dependencies(
            typeof(GetStringDataAsyncDelegate),
            typeof(ConvertJSONToListAccountProductDelegate))]
        public GetListAccountProductDataAsyncDelegate(
            IGetDataAsyncDelegate<string, string> getStringDataAsyncDelegate,
            IConvertDelegate<string, List<AccountProduct>> convertJSONToListAccountProductDelegate) :
            base(
                getStringDataAsyncDelegate,
                convertJSONToListAccountProductDelegate)
        {
            // ...
        }
    }
}