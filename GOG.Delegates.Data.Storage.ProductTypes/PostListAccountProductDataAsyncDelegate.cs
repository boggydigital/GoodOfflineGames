using System.Collections.Generic;
using Attributes;
using GOG.Delegates.Conversions.JSON;
using GOG.Models;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Storage;

namespace GOG.Delegates.Data.Storage.ProductTypes
{
    public class PostListAccountProductDataAsyncDelegate : PostJSONDataAsyncDelegate<List<AccountProduct>>
    {
        [Dependencies(
            typeof(PostStringDataAsyncDelegate),
            typeof(ConvertListAccountProductToJSONDelegate))]
        public PostListAccountProductDataAsyncDelegate(
            IPostDataAsyncDelegate<string> postStringDataAsyncDelegate,
            IConvertDelegate<List<AccountProduct>, string> convertListAccountProductToJSONDelegate) :
            base(
                postStringDataAsyncDelegate,
                convertListAccountProductToJSONDelegate)
        {
            // ...
        }
    }
}