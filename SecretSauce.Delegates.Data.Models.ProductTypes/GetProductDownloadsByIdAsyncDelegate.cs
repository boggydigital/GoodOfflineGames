using System.Collections.Generic;
using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Collections.Interfaces;
using SecretSauce.Delegates.Collections.ProductTypes;
using SecretSauce.Delegates.Conversions.Indexes.ProductTypes;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Storage.ProductTypes;

namespace SecretSauce.Delegates.Data.Models.ProductTypes
{
    public class GetProductDownloadsByIdAsyncDelegate :
        GetDataByIdAsyncDelegate<ProductDownloads>
    {
        [Dependencies(
            typeof(GetStoredListProductDownloadsDataAsyncDelegate),
            typeof(FindProductDownloadsDelegate),
            typeof(ConvertProductDownloadsToIndexDelegate))]
        public GetProductDownloadsByIdAsyncDelegate(
            IGetDataAsyncDelegate<List<ProductDownloads>, string> getDataCollectionAsyncDelegate,
            IFindDelegate<ProductDownloads> findDelegate,
            IConvertDelegate<ProductDownloads, long> convertProductToIndexDelegate) :
            base(
                getDataCollectionAsyncDelegate,
                findDelegate,
                convertProductToIndexDelegate)
        {
            // ...
        }
    }
}