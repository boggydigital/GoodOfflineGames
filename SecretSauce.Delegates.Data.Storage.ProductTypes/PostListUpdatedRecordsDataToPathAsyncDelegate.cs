using System.Collections.Generic;
using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Values.Interfaces;
using SecretSauce.Delegates.Values.Paths.ProductTypes;

namespace SecretSauce.Delegates.Data.Storage.ProductTypes
{
    public class PostListUpdatedRecordsDataToPathAsyncDelegate : PostJSONDataToPathAsyncDelegate<List<ProductRecords>>
    {
        [Dependencies(
            typeof(PostListProductRecordsDataAsyncDelegate),
            typeof(GetUpdatedRecordsPathDelegate))]
        public PostListUpdatedRecordsDataToPathAsyncDelegate(
            IPostDataAsyncDelegate<List<ProductRecords>> postListProductRecordsDataAsyncDelegate,
            IGetValueDelegate<string, (string Directory, string Filename)> getUpdatedRecordsPathDelegate) :
            base(
                postListProductRecordsDataAsyncDelegate,
                getUpdatedRecordsPathDelegate)
        {
            // ...
        }
    }
}