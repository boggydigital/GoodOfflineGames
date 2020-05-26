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
    public class UpdateProductDownloadsAsyncDelegate : UpdateDataAsyncDelegate<ProductDownloads>
    {
        [Dependencies(
            typeof(DeleteProductDownloadsAsyncDelegate),
            typeof(ConvertProductDownloadsToIndexDelegate),
            typeof(GetStoredListProductDownloadsDataAsyncDelegate))]
        public UpdateProductDownloadsAsyncDelegate(
            IDeleteAsyncDelegate<ProductDownloads> deleteAsyncDelegate,
            IConvertDelegate<ProductDownloads, long> convertProductToIndexDelegate,
            IGetDataAsyncDelegate<List<ProductDownloads>, string> getListProductDownloadsAsyncDelegate) :
            base(
                deleteAsyncDelegate,
                convertProductToIndexDelegate,
                getListProductDownloadsAsyncDelegate)
        {
            // ...
        }
    }
}