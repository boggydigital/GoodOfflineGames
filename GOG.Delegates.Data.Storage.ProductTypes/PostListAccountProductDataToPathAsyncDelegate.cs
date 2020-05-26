using System.Collections.Generic;
using Attributes;
using GOG.Models;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Storage;
using SecretSauce.Delegates.Values.Interfaces;
using SecretSauce.Delegates.Values.Paths.ProductTypes;

namespace GOG.Delegates.Data.Storage.ProductTypes
{
    public class PostListAccountProductDataToPathAsyncDelegate : PostJSONDataToPathAsyncDelegate<List<AccountProduct>>
    {
        [Dependencies(
            typeof(PostListAccountProductDataAsyncDelegate),
            typeof(GetAccountProductsPathDelegate))]
        public PostListAccountProductDataToPathAsyncDelegate(
            IPostDataAsyncDelegate<List<AccountProduct>> postListAccountProductDataAsyncDelegate,
            IGetValueDelegate<string, (string Directory, string Filename)> getAccountProductPathDelegate) :
            base(
                postListAccountProductDataAsyncDelegate,
                getAccountProductPathDelegate)
        {
            // ...
        }
    }
}