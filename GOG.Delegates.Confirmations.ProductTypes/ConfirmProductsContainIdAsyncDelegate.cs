using Attributes;
using GOG.Delegates.Data.Models.ProductTypes;
using GOG.Models;
using SecretSauce.Delegates.Confirmations;
using SecretSauce.Delegates.Data.Interfaces;

namespace GOG.Delegates.Confirmations.ProductTypes
{
    public class ConfirmProductsContainIdAsyncDelegate : ConfirmDataContainsIdAsyncDelegate<Product>
    {
        [Dependencies(
            typeof(GetProductByIdAsyncDelegate))]
        public ConfirmProductsContainIdAsyncDelegate(
            IGetDataAsyncDelegate<Product, long> getProductByIdAsyncDelegate) :
            base(getProductByIdAsyncDelegate)
        {
            // ...
        }
    }
}