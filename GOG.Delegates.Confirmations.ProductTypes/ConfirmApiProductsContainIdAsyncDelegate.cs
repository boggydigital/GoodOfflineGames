using Attributes;
using GOG.Delegates.Data.Models.ProductTypes;
using GOG.Models;
using SecretSauce.Delegates.Confirmations;
using SecretSauce.Delegates.Data.Interfaces;

namespace GOG.Delegates.Confirmations.ProductTypes
{
    public class ConfirmApiProductsContainIdAsyncDelegate : ConfirmDataContainsIdAsyncDelegate<ApiProduct>
    {
        [Dependencies(
            typeof(GetApiProductByIdAsyncDelegate))]
        public ConfirmApiProductsContainIdAsyncDelegate(
            IGetDataAsyncDelegate<ApiProduct, long> getApiProductByIdAsyncDelegate) :
            base(getApiProductByIdAsyncDelegate)
        {
            // ...
        }
    }
}