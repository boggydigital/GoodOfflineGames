using System.Collections.Generic;
using Attributes;
using GOG.Delegates.Conversions.JSON;
using GOG.Models;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Storage;

namespace GOG.Delegates.Data.Storage.ProductTypes
{
    public class GetListApiProductDataAsyncDelegate : GetJSONDataAsyncDelegate<List<ApiProduct>>
    {
        [Dependencies(
            typeof(GetStringDataAsyncDelegate),
            typeof(ConvertJSONToListApiProductDelegate))]
        public GetListApiProductDataAsyncDelegate(
            IGetDataAsyncDelegate<string, string> getStringDataAsyncDelegate,
            IConvertDelegate<string, List<ApiProduct>> convertJSONToListApiProductDelegate) :
            base(
                getStringDataAsyncDelegate,
                convertJSONToListApiProductDelegate)
        {
            // ...
        }
    }
}