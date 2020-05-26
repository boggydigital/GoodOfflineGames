using System.Collections.Generic;
using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Storage.ProductTypes;

namespace SecretSauce.Delegates.Itemizations.ProductTypes
{
    public class ItemizeAllProductDownloadsAsyncDelegate : ItemizeAllDataAsyncDelegate<ProductDownloads>
    {
        [Dependencies(
            typeof(GetStoredListProductDownloadsDataAsyncDelegate))]
        public ItemizeAllProductDownloadsAsyncDelegate(
            IGetDataAsyncDelegate<List<ProductDownloads>, string> getProductDownloadsAsyncDelegate) :
            base(getProductDownloadsAsyncDelegate)
        {
            // ...
        }
    }
}