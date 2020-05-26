using System.Collections.Generic;
using Models.ProductTypes;
using SecretSauce.Delegates.Confirmations.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Itemizations.Interfaces;

namespace SecretSauce.Delegates.Itemizations.MasterDetail
{
    // TODO: Deprecate trivial code
    public abstract class ItemizeAllMasterDetailsGapsAsyncDelegate<MasterType> :
        IItemizeAllAsyncDelegate<MasterType>
        where MasterType : ProductCore
    {
        private readonly IConfirmAsyncDelegate<long> confirmDetailDataContainsIdAsyncDelegate;
        private readonly IGetDataAsyncDelegate<IList<MasterType>, string> getMasterDataAsyncDelegate;

        public ItemizeAllMasterDetailsGapsAsyncDelegate(
            IGetDataAsyncDelegate<IList<MasterType>, string> getMasterDataAsyncDelegate,
            IConfirmAsyncDelegate<long> confirmDetailDataContainsIdAsyncDelegate)
        {
            this.getMasterDataAsyncDelegate = getMasterDataAsyncDelegate;
            this.confirmDetailDataContainsIdAsyncDelegate = confirmDetailDataContainsIdAsyncDelegate;
        }

        public async IAsyncEnumerable<MasterType> ItemizeAllAsync()
        {
            foreach (var masterDataValue in await getMasterDataAsyncDelegate.GetDataAsync(string.Empty))
                if (!await confirmDetailDataContainsIdAsyncDelegate.ConfirmAsync(masterDataValue.Id))
                    yield return masterDataValue;
        }
    }
}