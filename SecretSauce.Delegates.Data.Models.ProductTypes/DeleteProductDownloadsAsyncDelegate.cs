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
    public class DeleteProductDownloadsAsyncDelegate : DeleteAsyncDelegate<ProductDownloads>
    {
        [Dependencies(
            typeof(GetStoredListProductDownloadsDataAsyncDelegate),
            typeof(ConvertProductDownloadsToIndexDelegate))]
        public DeleteProductDownloadsAsyncDelegate(
            IGetDataAsyncDelegate<List<ProductDownloads>, string> getDataCollectionAsyncDelegate,
            IConvertDelegate<ProductDownloads, long> convertProductToIndexDelegate) :
            base(
                getDataCollectionAsyncDelegate,
                convertProductToIndexDelegate)
        {
            // ...
        }
    }
}