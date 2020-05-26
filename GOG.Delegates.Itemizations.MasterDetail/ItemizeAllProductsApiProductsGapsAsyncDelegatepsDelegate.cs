using System.Collections.Generic;
using Attributes;
using GOG.Delegates.Confirmations.ProductTypes;
using GOG.Delegates.Data.Storage.ProductTypes;
using GOG.Models;
using SecretSauce.Delegates.Confirmations.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Itemizations.MasterDetail;

namespace GOG.Delegates.Itemizations.MasterDetail
{
    public class ItemizeAllProductsApiProductsGapsAsyncDelegate :
        ItemizeAllMasterDetailsGapsAsyncDelegate<Product>
    {
        [Dependencies(
            typeof(GetStoredListProductDataAsyncDelegate),
            typeof(ConfirmApiProductsContainIdAsyncDelegate))]
        public ItemizeAllProductsApiProductsGapsAsyncDelegate(
            IGetDataAsyncDelegate<IList<Product>, string> getStoredProductDataAsyncDelegate,
            IConfirmAsyncDelegate<long> confirmApiProductsContainIdAsyncDelegate) :
            base(
                getStoredProductDataAsyncDelegate,
                confirmApiProductsContainIdAsyncDelegate)
        {
            // ...
        }
    }
}