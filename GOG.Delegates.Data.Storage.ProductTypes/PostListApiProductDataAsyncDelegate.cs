using System.Collections.Generic;
using Attributes;
using GOG.Delegates.Conversions.JSON;
using GOG.Models;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Storage;

namespace GOG.Delegates.Data.Storage.ProductTypes
{
    public class PostListApiProductDataAsyncDelegate : PostJSONDataAsyncDelegate<List<ApiProduct>>
    {
        [Dependencies(
            typeof(PostStringDataAsyncDelegate),
            typeof(ConvertListApiProductToJSONDelegate))]
        public PostListApiProductDataAsyncDelegate(
            IPostDataAsyncDelegate<string> postStringDataAsyncDelegate,
            IConvertDelegate<List<ApiProduct>, string> convertListApiProductToJSONDelegate) :
            base(
                postStringDataAsyncDelegate,
                convertListApiProductToJSONDelegate)
        {
            // ...
        }
    }
}