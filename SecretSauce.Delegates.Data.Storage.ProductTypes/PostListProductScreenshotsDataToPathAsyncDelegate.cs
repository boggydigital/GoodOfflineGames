using System.Collections.Generic;
using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Values.Interfaces;
using SecretSauce.Delegates.Values.Paths.ProductTypes;

namespace SecretSauce.Delegates.Data.Storage.ProductTypes
{
    public class
        PostListProductScreenshotsDataToPathAsyncDelegate : PostJSONDataToPathAsyncDelegate<List<ProductScreenshots>>
    {
        [Dependencies(
            typeof(PostListProductScreenshotsDataAsyncDelegate),
            typeof(GetProductScreenshotsPathDelegate))]
        public PostListProductScreenshotsDataToPathAsyncDelegate(
            IPostDataAsyncDelegate<List<ProductScreenshots>> postListProductScreenshotsDataAsyncDelegate,
            IGetValueDelegate<string, (string Directory, string Filename)> getListProductScreenshotsPathDelegate) :
            base(
                postListProductScreenshotsDataAsyncDelegate,
                getListProductScreenshotsPathDelegate)
        {
            // ...
        }
    }
}