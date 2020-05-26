using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Models.ProductTypes;

namespace SecretSauce.Delegates.Confirmations.ProductTypes
{
    public class ConfirmProductRoutesContainIdAsyncDelegate :
        ConfirmDataContainsIdAsyncDelegate<ProductRoutes>
    {
        [Dependencies(
            typeof(GetProductRoutesByIdAsyncDelegate))]
        public ConfirmProductRoutesContainIdAsyncDelegate(
            IGetDataAsyncDelegate<ProductRoutes, long> getDataByIdAsyncDelegate) :
            base(getDataByIdAsyncDelegate)
        {
            // ...
        }
    }
}