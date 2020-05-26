using System.Collections.Generic;
using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Values.Interfaces;
using SecretSauce.Delegates.Values.Paths.ProductTypes;

namespace SecretSauce.Delegates.Data.Storage.ProductTypes
{
    public class
        PostListGameDetailsRecordsDataToPathAsyncDelegate : PostJSONDataToPathAsyncDelegate<List<ProductRecords>>
    {
        [Dependencies(
            typeof(PostListProductRecordsDataAsyncDelegate),
            typeof(GetGameDetailsRecordsPathDelegate))]
        public PostListGameDetailsRecordsDataToPathAsyncDelegate(
            IPostDataAsyncDelegate<List<ProductRecords>> postListProductRecordsDataAsyncDelegate,
            IGetValueDelegate<string, (string Directory, string Filename)> getGameDetailsRecordsPathDelegate) :
            base(
                postListProductRecordsDataAsyncDelegate,
                getGameDetailsRecordsPathDelegate)
        {
            // ...
        }
    }
}