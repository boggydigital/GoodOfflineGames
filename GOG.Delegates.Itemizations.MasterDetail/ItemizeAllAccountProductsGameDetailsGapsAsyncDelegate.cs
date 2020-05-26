using System.Collections.Generic;
using Attributes;
using GOG.Delegates.Confirmations.ProductTypes;
using GOG.Delegates.Data.Storage.ProductTypes;
using GOG.Delegates.Itemizations.ProductTypes;
using GOG.Models;
using SecretSauce.Delegates.Confirmations.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Itemizations.Interfaces;
using SecretSauce.Delegates.Itemizations.MasterDetail;

namespace GOG.Delegates.Itemizations.MasterDetail
{
    public class ItemizeAllAccountProductsGameDetailsGapsAsyncDelegate :
        ItemizeAllMasterDetailsGapsAsyncDelegate<AccountProduct>
    {
        [Dependencies(
            typeof(GetStoredListAccountProductDataAsyncDelegate),
            typeof(ConfirmGameDetailsContainIdAsyncDelegate))]
        public ItemizeAllAccountProductsGameDetailsGapsAsyncDelegate(
            IGetDataAsyncDelegate<IList<AccountProduct>, string> getStoredListAccountProductDataAsyncDelegate,
            IConfirmAsyncDelegate<long> confirmGameDetailsContainsIdAsyncDelegate) :
            base(
                getStoredListAccountProductDataAsyncDelegate,
                confirmGameDetailsContainsIdAsyncDelegate)
        {
            // ...
        }
    }
}