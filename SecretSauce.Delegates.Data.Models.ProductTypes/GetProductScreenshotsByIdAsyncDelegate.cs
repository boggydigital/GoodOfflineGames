using System.Collections.Generic;
using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Collections.Interfaces;
using SecretSauce.Delegates.Conversions.Indexes.ProductTypes;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Storage.ProductTypes;

namespace SecretSauce.Delegates.Data.Models.ProductTypes
{
    public class GetProductScreenshotsByIdAsyncDelegate :
        GetDataByIdAsyncDelegate<ProductScreenshots>
    {
        [Dependencies(
            typeof(GetStoredListProductScreenshotsDataAsyncDelegate),
            typeof(Delegates.Collections.ProductTypes.FindProductScreenshotsDelegate),
            typeof(ConvertProductScreenshotsToIndexDelegate))]
        public GetProductScreenshotsByIdAsyncDelegate(
            IGetDataAsyncDelegate<List<ProductScreenshots>, string> getDataCollectionAsyncDelegate,
            IFindDelegate<ProductScreenshots> findDelegate,
            IConvertDelegate<ProductScreenshots, long> convertProductToIndexDelegate) :
            base(
                getDataCollectionAsyncDelegate,
                findDelegate,
                convertProductToIndexDelegate)
        {
            // ...
        }
    }
}