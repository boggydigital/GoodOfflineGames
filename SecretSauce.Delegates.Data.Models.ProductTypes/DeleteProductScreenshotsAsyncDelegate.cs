using System.Collections.Generic;
using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Confirmations.Interfaces;
using SecretSauce.Delegates.Conversions.Indexes.ProductTypes;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Storage.ProductTypes;

namespace SecretSauce.Delegates.Data.Models.ProductTypes
{
    public class DeleteProductScreenshotsAsyncDelegate : DeleteAsyncDelegate<ProductScreenshots>
    {
        [Dependencies(
            typeof(GetStoredListProductScreenshotsDataAsyncDelegate),
            typeof(ConvertProductScreenshotsToIndexDelegate))]
        public DeleteProductScreenshotsAsyncDelegate(
            IGetDataAsyncDelegate<List<ProductScreenshots>, string> getDataCollectionAsyncDelegate,
            IConvertDelegate<ProductScreenshots, long> convertProductToIndexDelegate) :
            base(
                getDataCollectionAsyncDelegate,
                convertProductToIndexDelegate)
        {
            // ...
        }
    }
}