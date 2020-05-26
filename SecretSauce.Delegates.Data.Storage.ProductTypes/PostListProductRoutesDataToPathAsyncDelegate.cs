using System.Collections.Generic;
using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Values.Interfaces;
using SecretSauce.Delegates.Values.Paths.ProductTypes;

namespace SecretSauce.Delegates.Data.Storage.ProductTypes
{
    public class PostListProductRoutesDataToPathAsyncDelegate : PostJSONDataToPathAsyncDelegate<List<ProductRoutes>>
    {
        [Dependencies(
            typeof(PostListProductRoutesDataAsyncDelegate),
            typeof(GetProductRoutesPathDelegate))]
        public PostListProductRoutesDataToPathAsyncDelegate(
            IPostDataAsyncDelegate<List<ProductRoutes>> postListProductRoutesDataAsyncDelegate,
            IGetValueDelegate<string, (string Directory, string Filename)> getListProductRoutesPathDelegate) :
            base(
                postListProductRoutesDataAsyncDelegate,
                getListProductRoutesPathDelegate)
        {
            // ...
        }
    }
}