using System.Collections.Generic;
using Attributes;
using GOG.Delegates.Conversions.Indexes.ProductTypes;
using GOG.Delegates.Data.Storage.ProductTypes;
using GOG.Models;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Models;

namespace GOG.Delegates.Data.Models.ProductTypes
{
    public class DeleteGameDetailsAsyncDelegate : DeleteAsyncDelegate<GameDetails>
    {
        [Dependencies(
            typeof(GetStoredListGameDetailsDataAsyncDelegate),
            typeof(ConvertGameDetailsToIndexDelegate))]
        public DeleteGameDetailsAsyncDelegate(
            IGetDataAsyncDelegate<List<GameDetails>, string> getDataCollectionAsyncDelegate,
            IConvertDelegate<GameDetails, long> convertProductToIndexDelegate) :
            base(
                getDataCollectionAsyncDelegate,
                convertProductToIndexDelegate)
        {
            // ...
        }
    }
}