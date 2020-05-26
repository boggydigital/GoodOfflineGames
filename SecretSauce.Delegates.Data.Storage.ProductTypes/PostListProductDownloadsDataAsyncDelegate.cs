using System.Collections.Generic;
using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Conversions.JSON.ProductTypes;
using SecretSauce.Delegates.Data.Interfaces;

namespace SecretSauce.Delegates.Data.Storage.ProductTypes
{
    public class PostListProductDownloadsDataAsyncDelegate : PostJSONDataAsyncDelegate<List<ProductDownloads>>
    {
        [Dependencies(
            typeof(PostStringDataAsyncDelegate),
            typeof(ConvertListProductDownloadsToJSONDelegate))]
        public PostListProductDownloadsDataAsyncDelegate(
            IPostDataAsyncDelegate<string> postStringDataAsyncDelegate,
            IConvertDelegate<List<ProductDownloads>, string> convertListProductDownloadsToJSONDelegate) :
            base(
                postStringDataAsyncDelegate,
                convertListProductDownloadsToJSONDelegate)
        {
            // ...
        }
    }
}