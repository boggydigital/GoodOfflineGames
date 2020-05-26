using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Models.ProductTypes;

namespace SecretSauce.Delegates.Confirmations.ProductTypes
{
    public class ConfirmProductScreenshotsContainIdAsyncDelegate :
        ConfirmDataContainsIdAsyncDelegate<ProductScreenshots>
    {
        [Dependencies(
            typeof(GetProductScreenshotsByIdAsyncDelegate))]
        public ConfirmProductScreenshotsContainIdAsyncDelegate(
            IGetDataAsyncDelegate<ProductScreenshots, long> getDataByIdAsyncDelegate) :
            base(getDataByIdAsyncDelegate)
        {
            // ...
        }
    }
}