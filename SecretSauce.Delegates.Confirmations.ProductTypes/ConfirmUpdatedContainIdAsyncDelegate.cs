using Attributes;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Models.ProductTypes;

namespace SecretSauce.Delegates.Confirmations.ProductTypes
{
    // TODO: This and wishlisted should be a form of passthrough
    public class ConfirmUpdatedContainIdAsyncDelegate : ConfirmDataContainsIdAsyncDelegate<long>
    {
        [Dependencies(
            typeof(GetUpdatedByIdAsyncDelegate))]
        public ConfirmUpdatedContainIdAsyncDelegate(
            IGetDataAsyncDelegate<long, long> getDataByIdAsyncDelegate) :
            base(getDataByIdAsyncDelegate)
        {
            // ...
        }
    }
}