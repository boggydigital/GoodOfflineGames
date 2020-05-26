using System.Collections.Generic;
using Attributes;
using GOG.Models;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Storage;
using SecretSauce.Delegates.Values.Interfaces;
using SecretSauce.Delegates.Values.Paths.ProductTypes;

namespace GOG.Delegates.Data.Storage.ProductTypes
{
    public class GetStoredListGameDetailsDataAsyncDelegate : GetStoredJSONDataAsyncDelegate<List<GameDetails>>
    {
        [Dependencies(
            typeof(GetListGameDetailsDataAsyncDelegate),
            typeof(GetGameDetailsPathDelegate))]
        public GetStoredListGameDetailsDataAsyncDelegate(
            IGetDataAsyncDelegate<List<GameDetails>, string> getListGameDetailsDataAsyncDelegate,
            IGetValueDelegate<string, (string Directory, string Filename)> getGameDetailsPathDelegate) :
            base(
                getListGameDetailsDataAsyncDelegate,
                getGameDetailsPathDelegate)
        {
            // ...
        }
    }
}