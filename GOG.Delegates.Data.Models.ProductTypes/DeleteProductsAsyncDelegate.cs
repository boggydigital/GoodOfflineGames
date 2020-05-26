using System.Collections.Generic;
using Attributes;
using GOG.Delegates.Conversions.Indexes.ProductTypes;
using GOG.Delegates.Data.Storage.ProductTypes;
using GOG.Models;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Models;

namespace GOG.Delegates.Data.Models.ProductTypes
{
    public class DeleteProductsAsyncDelegate : DeleteAsyncDelegate<Product>
    {
        [Dependencies(
            typeof(GetStoredListProductDataAsyncDelegate),
            typeof(ConvertProductToIndexDelegate))]
        public DeleteProductsAsyncDelegate(
            IGetDataAsyncDelegate<List<Product>, string> getDataCollectionAsyncDelegate,
            IConvertDelegate<Product, long> convertProductToIndexDelegate) :
            base(
                getDataCollectionAsyncDelegate,
                convertProductToIndexDelegate)
        {
            // ...
        }
    }
}