using System.Collections.Generic;
using Attributes;
using GOG.Models;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Storage;
using SecretSauce.Delegates.Values.Interfaces;
using SecretSauce.Delegates.Values.Paths.ProductTypes;

namespace GOG.Delegates.Data.Storage.ProductTypes
{
    public class GetStoredListProductDataAsyncDelegate : GetStoredJSONDataAsyncDelegate<List<Product>>
    {
        [Dependencies(
            typeof(GetListProductDataAsyncDelegate),
            typeof(GetProductsPathDelegate))]
        public GetStoredListProductDataAsyncDelegate(
            IGetDataAsyncDelegate<List<Product>, string> getListProductDataAsyncDelegate,
            IGetValueDelegate<string, (string Directory, string Filename)> getProductsPathDelegate) :
            base(
                getListProductDataAsyncDelegate,
                getProductsPathDelegate)
        {
            // ...
        }
    }
}