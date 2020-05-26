using System.Collections.Generic;
using Attributes;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Values.Interfaces;
using SecretSauce.Delegates.Values.Paths.ProductTypes;

namespace SecretSauce.Delegates.Data.Storage.ProductTypes
{
    public class PostListUpdatedDataToPathAsyncDelegate : PostJSONDataToPathAsyncDelegate<List<long>>
    {
        [Dependencies(
            typeof(PostListUpdatedDataAsyncDelegate),
            typeof(GetUpdatedPathDelegate))]
        public PostListUpdatedDataToPathAsyncDelegate(
            IPostDataAsyncDelegate<List<long>> postListUpdatedDataAsyncDelegate,
            IGetValueDelegate<string, (string Directory, string Filename)> getUpdatedPathDelegate) :
            base(
                postListUpdatedDataAsyncDelegate,
                getUpdatedPathDelegate)
        {
            // ...
        }
    }
}