using System.Collections.Generic;
using Attributes;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Values.Interfaces;
using SecretSauce.Delegates.Values.Paths.ProductTypes;

namespace SecretSauce.Delegates.Data.Storage.ProductTypes
{
    public class PostListWishlistedDataToPathAsyncDelegate : PostJSONDataToPathAsyncDelegate<List<long>>
    {
        [Dependencies(
            typeof(PostListWishlistedDataAsyncDelegate),
            typeof(GetWishlistedPathDelegate))]
        public PostListWishlistedDataToPathAsyncDelegate(
            IPostDataAsyncDelegate<List<long>> postListWishlistedDataAsyncDelegate,
            IGetValueDelegate<string, (string Directory, string Filename)> getWishlistedPathDelegate) :
            base(
                postListWishlistedDataAsyncDelegate,
                getWishlistedPathDelegate)
        {
            // ...
        }
    }
}