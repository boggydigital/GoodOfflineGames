using System.Collections.Generic;
using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Conversions.JSON.ProductTypes;
using SecretSauce.Delegates.Data.Interfaces;

namespace SecretSauce.Delegates.Data.Storage.ProductTypes
{
    public class PostListProductRecordsDataAsyncDelegate : PostJSONDataAsyncDelegate<List<ProductRecords>>
    {
        [Dependencies(
            typeof(PostStringDataAsyncDelegate),
            typeof(ConvertListProductRecordsToJSONDelegate))]
        public PostListProductRecordsDataAsyncDelegate(
            IPostDataAsyncDelegate<string> postStringDataAsyncDelegate,
            IConvertDelegate<List<ProductRecords>, string> convertListProductRecordsToJSONDelegate) :
            base(
                postStringDataAsyncDelegate,
                convertListProductRecordsToJSONDelegate)
        {
            // ...
        }
    }
}