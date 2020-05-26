using System.Collections.Generic;
using Attributes;
using GOG.Delegates.Conversions.JSON;
using GOG.Models;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Storage;

namespace GOG.Delegates.Data.Storage.ProductTypes
{
    public class PostListGameDetailsDataAsyncDelegate : PostJSONDataAsyncDelegate<List<GameDetails>>
    {
        [Dependencies(
            typeof(PostStringDataAsyncDelegate),
            typeof(ConvertListGameDetailsToJSONDelegate))]
        public PostListGameDetailsDataAsyncDelegate(
            IPostDataAsyncDelegate<string> postStringDataAsyncDelegate,
            IConvertDelegate<List<GameDetails>, string> convertListGameDetailsToJSONDelegate) :
            base(
                postStringDataAsyncDelegate,
                convertListGameDetailsToJSONDelegate)
        {
            // ...
        }
    }
}