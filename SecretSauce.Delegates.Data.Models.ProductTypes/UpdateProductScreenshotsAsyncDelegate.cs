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
    public class UpdateProductScreenshotsAsyncDelegate : UpdateDataAsyncDelegate<ProductScreenshots>
    {
        [Dependencies(
            typeof(DeleteProductScreenshotsAsyncDelegate),
            typeof(ConvertProductScreenshotsToIndexDelegate),
            typeof(GetStoredListProductScreenshotsDataAsyncDelegate))]
        public UpdateProductScreenshotsAsyncDelegate(
            IDeleteAsyncDelegate<ProductScreenshots> deleteAsyncDelegate,
            IConvertDelegate<ProductScreenshots, long> convertProductToIndexDelegate,
            IGetDataAsyncDelegate<List<ProductScreenshots>, string> getListProductScreenshotsAsyncDelegate) :
            base(
                deleteAsyncDelegate,
                convertProductToIndexDelegate,
                getListProductScreenshotsAsyncDelegate)
        {
            // ...
        }
    }
}