using System.Collections.Generic;
using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Values.Interfaces;
using SecretSauce.Delegates.Values.Paths.ProductTypes;

namespace SecretSauce.Delegates.Data.Storage.ProductTypes
{
    public class
        PostListWishlistedRecordsDataToPathAsyncDelegate : PostJSONDataToPathAsyncDelegate<List<ProductRecords>>
    {
        [Dependencies(
            typeof(PostListProductRecordsDataAsyncDelegate),
            typeof(GetWishlistedRecordsPathDelegate))]
        public PostListWishlistedRecordsDataToPathAsyncDelegate(
            IPostDataAsyncDelegate<List<ProductRecords>> postListProductRecordsDataAsyncDelegate,
            IGetValueDelegate<string, (string Directory, string Filename)> getWishlistedRecordsPathDelegate) :
            base(
                postListProductRecordsDataAsyncDelegate,
                getWishlistedRecordsPathDelegate)
        {
            // ...
        }
    }
}