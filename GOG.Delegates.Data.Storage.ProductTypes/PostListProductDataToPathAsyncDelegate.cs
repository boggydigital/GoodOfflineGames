using System.Collections.Generic;
using Attributes;
using GOG.Models;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Storage;
using SecretSauce.Delegates.Values.Interfaces;
using SecretSauce.Delegates.Values.Paths.ProductTypes;

namespace GOG.Delegates.Data.Storage.ProductTypes
{
    public class PostListProductDataToPathAsyncDelegate : PostJSONDataToPathAsyncDelegate<List<Product>>
    {
        [Dependencies(
            typeof(PostListProductDataAsyncDelegate),
            typeof(GetProductsPathDelegate))]
        public PostListProductDataToPathAsyncDelegate(
            IPostDataAsyncDelegate<List<Product>> postListProductDataAsyncDelegate,
            IGetValueDelegate<string, (string Directory, string Filename)> getProductPathDelegate) :
            base(
                postListProductDataAsyncDelegate,
                getProductPathDelegate)
        {
            // ...
        }
    }
}