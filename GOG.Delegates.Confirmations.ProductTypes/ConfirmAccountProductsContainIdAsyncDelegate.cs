using Attributes;
using GOG.Delegates.Data.Models.ProductTypes;
using GOG.Models;
using SecretSauce.Delegates.Confirmations;
using SecretSauce.Delegates.Data.Interfaces;

namespace GOG.Delegates.Confirmations.ProductTypes
{
    public class ConfirmAccountProductsContainIdAsyncDelegate : ConfirmDataContainsIdAsyncDelegate<AccountProduct>
    {
        [Dependencies(
            typeof(GetAccountProductByIdAsyncDelegate))]
        public ConfirmAccountProductsContainIdAsyncDelegate(
            IGetDataAsyncDelegate<AccountProduct, long> getAccountProductByIdAsyncDelegate) :
            base(getAccountProductByIdAsyncDelegate)
        {
            // ...
        }
    }
}