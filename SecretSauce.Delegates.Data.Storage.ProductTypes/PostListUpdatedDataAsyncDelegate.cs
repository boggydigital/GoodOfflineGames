using System.Collections.Generic;
using Attributes;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Conversions.JSON.System;
using SecretSauce.Delegates.Data.Interfaces;

namespace SecretSauce.Delegates.Data.Storage.ProductTypes
{
    public class PostListUpdatedDataAsyncDelegate : PostJSONDataAsyncDelegate<List<long>>
    {
        [Dependencies(
            typeof(PostStringDataAsyncDelegate),
            typeof(ConvertListLongToJSONDelegate))]
        public PostListUpdatedDataAsyncDelegate(
            IPostDataAsyncDelegate<string> postStringDataAsyncDelegate,
            IConvertDelegate<List<long>, string> convertListLongToJSONDelegate) :
            base(
                postStringDataAsyncDelegate,
                convertListLongToJSONDelegate)
        {
            // ...
        }
    }
}