using System.Collections.Generic;
using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Values.Interfaces;
using SecretSauce.Delegates.Values.Paths.ProductTypes;

namespace SecretSauce.Delegates.Data.Storage.ProductTypes
{
    public class
        PostListProductDownloadsDataToPathAsyncDelegate : PostJSONDataToPathAsyncDelegate<List<ProductDownloads>>
    {
        [Dependencies(
            typeof(PostListProductDownloadsDataAsyncDelegate),
            typeof(GetProductDownloadsPathDelegate))]
        public PostListProductDownloadsDataToPathAsyncDelegate(
            IPostDataAsyncDelegate<List<ProductDownloads>> postListProductDownloadsDataAsyncDelegate,
            IGetValueDelegate<string, (string Directory, string Filename)> getProductDownloadsPathDelegate) :
            base(
                postListProductDownloadsDataAsyncDelegate,
                getProductDownloadsPathDelegate)
        {
            // ...
        }
    }
}