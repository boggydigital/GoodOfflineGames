using System.Collections.Generic;
using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Conversions.JSON.ProductTypes;
using SecretSauce.Delegates.Data.Interfaces;

namespace SecretSauce.Delegates.Data.Storage.ProductTypes
{
    public class PostListProductRoutesDataAsyncDelegate : PostJSONDataAsyncDelegate<List<ProductRoutes>>
    {
        [Dependencies(
            typeof(PostStringDataAsyncDelegate),
            typeof(ConvertListProductRoutesToJSONDelegate))]
        public PostListProductRoutesDataAsyncDelegate(
            IPostDataAsyncDelegate<string> postStringDataAsyncDelegate,
            IConvertDelegate<List<ProductRoutes>, string> convertListProductRoutesToJSONDelegate) :
            base(
                postStringDataAsyncDelegate,
                convertListProductRoutesToJSONDelegate)
        {
            // ...
        }
    }
}