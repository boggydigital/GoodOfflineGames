using System.Collections.Generic;
using Attributes;
using Delegates.Itemizations;
using GOG.Models;
using Interfaces.Delegates.Data;

namespace GOG.Delegates.Itemizations.ProductTypes
{
    public class ItemizeAllGameDetailsAsyncDelegate: ItemizeAllDataAsyncDelegate<GameDetails>
    {
        [Dependencies(
            typeof(GOG.Delegates.Data.Storage.ProductTypes.GetStoredListGameDetailsDataAsyncDelegate))]
        public ItemizeAllGameDetailsAsyncDelegate(
            IGetDataAsyncDelegate<List<GameDetails>, string> getListGameDetailsAsyncDelegate) : 
            base(getListGameDetailsAsyncDelegate)
        {
            // ...
        }
    }
}