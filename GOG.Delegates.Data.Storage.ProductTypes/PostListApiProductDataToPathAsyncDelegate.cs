using System.Collections.Generic;
using Attributes;
using GOG.Models;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Storage;
using SecretSauce.Delegates.Values.Interfaces;
using SecretSauce.Delegates.Values.Paths.ProductTypes;

namespace GOG.Delegates.Data.Storage.ProductTypes
{
    public class PostListApiProductDataToPathAsyncDelegate : PostJSONDataToPathAsyncDelegate<List<ApiProduct>>
    {
        [Dependencies(
            typeof(PostListApiProductDataAsyncDelegate),
            typeof(GetApiProductsPathDelegate))]
        public PostListApiProductDataToPathAsyncDelegate(
            IPostDataAsyncDelegate<List<ApiProduct>> postListApiProductDataAsyncDelegate,
            IGetValueDelegate<string, (string Directory, string Filename)> getApiProductPathDelegate) :
            base(
                postListApiProductDataAsyncDelegate,
                getApiProductPathDelegate)
        {
            // ...
        }
    }
}