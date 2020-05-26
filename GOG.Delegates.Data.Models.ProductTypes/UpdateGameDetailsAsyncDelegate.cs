using System.Collections.Generic;
using Attributes;
using GOG.Delegates.Conversions.Indexes.ProductTypes;
using GOG.Delegates.Conversions.ProductTypes;
using GOG.Delegates.Data.Storage.ProductTypes;
using GOG.Models;
using SecretSauce.Delegates.Confirmations.Interfaces;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Models;

namespace GOG.Delegates.Data.Models.ProductTypes
{
    public class UpdateGameDetailsAsyncDelegate : UpdateDataAsyncDelegate<GameDetails>
    {
        [Dependencies(
            typeof(DeleteGameDetailsAsyncDelegate),
            typeof(ConvertGameDetailsToIndexDelegate),
            typeof(GetStoredListGameDetailsDataAsyncDelegate))]
        public UpdateGameDetailsAsyncDelegate(
            IDeleteAsyncDelegate<GameDetails> deleteGameDetailsAsyncDelegate,
            IConvertDelegate<GameDetails, long> convertGameDetailsToIndexDelegate,
            IGetDataAsyncDelegate<List<GameDetails>, string> getGameDetailsAsyncDelegate) :
            base(
                deleteGameDetailsAsyncDelegate,
                convertGameDetailsToIndexDelegate,
                getGameDetailsAsyncDelegate)
        {
            // ...
        }
    }
}