using System.Collections.Generic;
using Attributes;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Conversions.JSON.System;
using SecretSauce.Delegates.Data.Interfaces;

namespace SecretSauce.Delegates.Data.Storage.ProductTypes
{
    public class GetListWishlistedDataAsyncDelegate : GetJSONDataAsyncDelegate<List<long>>
    {
        [Dependencies(
            typeof(GetStringDataAsyncDelegate),
            typeof(ConvertJSONToListLongDelegate))]
        public GetListWishlistedDataAsyncDelegate(
            IGetDataAsyncDelegate<string, string> getStringDataAsyncDelegate,
            IConvertDelegate<string, List<long>> convertJSONToListLongDelegate) :
            base(
                getStringDataAsyncDelegate,
                convertJSONToListLongDelegate)
        {
            // ...
        }
    }
}