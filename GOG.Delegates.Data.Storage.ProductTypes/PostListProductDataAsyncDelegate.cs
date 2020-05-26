using System.Collections.Generic;
using Attributes;
using GOG.Delegates.Conversions.JSON;
using GOG.Models;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Storage;

namespace GOG.Delegates.Data.Storage.ProductTypes
{
    public class PostListProductDataAsyncDelegate : PostJSONDataAsyncDelegate<List<Product>>
    {
        [Dependencies(
            typeof(PostStringDataAsyncDelegate),
            typeof(ConvertListProductToJSONDelegate))]
        public PostListProductDataAsyncDelegate(
            IPostDataAsyncDelegate<string> postStringDataAsyncDelegate,
            IConvertDelegate<List<Product>, string> convertListProductToJSONDelegate) :
            base(
                postStringDataAsyncDelegate,
                convertListProductToJSONDelegate)
        {
            // ...
        }
    }
}