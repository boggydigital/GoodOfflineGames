using System.Collections.Generic;
using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Conversions.JSON.ProductTypes;
using SecretSauce.Delegates.Data.Interfaces;

namespace SecretSauce.Delegates.Data.Storage.ProductTypes
{
    public class GetListProductRecordsDataAsyncDelegate : GetJSONDataAsyncDelegate<List<ProductRecords>>
    {
        [Dependencies(
            typeof(GetStringDataAsyncDelegate),
            typeof(ConvertJSONToListProductRecordsDelegate))]
        public GetListProductRecordsDataAsyncDelegate(
            IGetDataAsyncDelegate<string, string> getStringDataAsyncDelegate,
            IConvertDelegate<string, List<ProductRecords>> convertJSONToListProductRecordsDelegate) :
            base(
                getStringDataAsyncDelegate,
                convertJSONToListProductRecordsDelegate)
        {
            // ...
        }
    }
}