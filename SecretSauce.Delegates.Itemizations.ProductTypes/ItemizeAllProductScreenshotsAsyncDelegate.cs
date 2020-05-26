using System.Collections.Generic;
using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Storage.ProductTypes;

namespace SecretSauce.Delegates.Itemizations.ProductTypes
{
    public class ItemizeAllProductScreenshotsAsyncDelegate : ItemizeAllDataAsyncDelegate<ProductScreenshots>
    {
        [Dependencies(
            typeof(GetStoredListProductScreenshotsDataAsyncDelegate))]
        public ItemizeAllProductScreenshotsAsyncDelegate(
            IGetDataAsyncDelegate<List<ProductScreenshots>, string> getProductScreenshotsAsyncDelegate) :
            base(getProductScreenshotsAsyncDelegate)
        {
            // ...
        }
    }
}