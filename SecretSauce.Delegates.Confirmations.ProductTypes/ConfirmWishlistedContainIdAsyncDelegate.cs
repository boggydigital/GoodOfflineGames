using Attributes;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Models.ProductTypes;

namespace SecretSauce.Delegates.Confirmations.ProductTypes
{
    public class ConfirmWishlistedContainIdAsyncDelegate : ConfirmDataContainsIdAsyncDelegate<long>
    {
        [Dependencies(
            typeof(GetWishlistedByIdAsyncDelegate))]
        public ConfirmWishlistedContainIdAsyncDelegate(
            IGetDataAsyncDelegate<long, long> getDataByIdAsyncDelegate) :
            base(getDataByIdAsyncDelegate)
        {
            // ...
        }
    }
}