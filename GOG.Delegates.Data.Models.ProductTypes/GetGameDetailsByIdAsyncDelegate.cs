using System.Collections.Generic;
using Attributes;
using GOG.Delegates.Collections.ProductTypes;
using GOG.Delegates.Conversions.Indexes.ProductTypes;
using GOG.Delegates.Conversions.ProductTypes;
using GOG.Delegates.Data.Storage.ProductTypes;
using GOG.Models;
using SecretSauce.Delegates.Collections.Interfaces;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Models;

namespace GOG.Delegates.Data.Models.ProductTypes
{
    public class GetGameDetailsByIdAsyncDelegate : GetDataByIdAsyncDelegate<GameDetails>
    {
        [Dependencies(
            typeof(GetStoredListGameDetailsDataAsyncDelegate),
            typeof(FindGameDetailsDelegate),
            typeof(ConvertGameDetailsToIndexDelegate))]
        public GetGameDetailsByIdAsyncDelegate(
            IGetDataAsyncDelegate<List<GameDetails>, string> getListGameDetailsAsyncDelegate,
            IFindDelegate<GameDetails> findDelegate,
            IConvertDelegate<GameDetails, long> convertProductToIndexDelegate) :
            base(
                getListGameDetailsAsyncDelegate,
                findDelegate,
                convertProductToIndexDelegate)
        {
            // ...
        }
    }
}