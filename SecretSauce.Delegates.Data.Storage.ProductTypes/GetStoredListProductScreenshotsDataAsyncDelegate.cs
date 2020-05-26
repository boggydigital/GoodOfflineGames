using System.Collections.Generic;
using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Values.Interfaces;
using SecretSauce.Delegates.Values.Paths.ProductTypes;

namespace SecretSauce.Delegates.Data.Storage.ProductTypes
{
    public class
        GetStoredListProductScreenshotsDataAsyncDelegate : GetStoredJSONDataAsyncDelegate<List<ProductScreenshots>>
    {
        [Dependencies(
            typeof(GetListProductScreenshotsDataAsyncDelegate),
            typeof(GetProductScreenshotsPathDelegate))]
        public GetStoredListProductScreenshotsDataAsyncDelegate(
            IGetDataAsyncDelegate<List<ProductScreenshots>, string> getListProductScreenshotsDataAsyncDelegate,
            IGetValueDelegate<string, (string Directory, string Filename)> getProductScreenshotsPathDelegate) :
            base(
                getListProductScreenshotsDataAsyncDelegate,
                getProductScreenshotsPathDelegate)
        {
            // ...
        }
    }
}