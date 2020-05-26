using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Models.ProductTypes;

namespace SecretSauce.Delegates.Confirmations.ProductTypes
{
    public class ConfirmProductDownloadsContainIdAsyncDelegate :
        ConfirmDataContainsIdAsyncDelegate<ProductDownloads>
    {
        [Dependencies(
            typeof(GetProductDownloadsByIdAsyncDelegate))]
        public ConfirmProductDownloadsContainIdAsyncDelegate(
            IGetDataAsyncDelegate<ProductDownloads, long> getDataByIdAsyncDelegate) :
            base(getDataByIdAsyncDelegate)
        {
            // ...
        }
    }
}