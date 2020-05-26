using System.Collections.Generic;
using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Conversions.JSON.ProductTypes;
using SecretSauce.Delegates.Data.Interfaces;

namespace SecretSauce.Delegates.Data.Storage.ProductTypes
{
    public class PostListProductScreenshotsDataAsyncDelegate : PostJSONDataAsyncDelegate<List<ProductScreenshots>>
    {
        [Dependencies(
            typeof(PostStringDataAsyncDelegate),
            typeof(ConvertListProductScreenshotsToJSONDelegate))]
        public PostListProductScreenshotsDataAsyncDelegate(
            IPostDataAsyncDelegate<string> postStringDataAsyncDelegate,
            IConvertDelegate<List<ProductScreenshots>, string> convertListProductScreenshotsToJSONDelegate) :
            base(
                postStringDataAsyncDelegate,
                convertListProductScreenshotsToJSONDelegate)
        {
            // ...
        }
    }
}