using System.Collections.Generic;
using Attributes;
using GOG.Delegates.Conversions.JSON;
using GOG.Models;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Storage;

namespace GOG.Delegates.Data.Storage.ProductTypes
{
    public class GetListGameDetailsDataAsyncDelegate : GetJSONDataAsyncDelegate<List<GameDetails>>
    {
        [Dependencies(
            typeof(GetStringDataAsyncDelegate),
            typeof(ConvertJSONToListGameDetailsDelegate))]
        public GetListGameDetailsDataAsyncDelegate(
            IGetDataAsyncDelegate<string, string> getStringDataAsyncDelegate,
            IConvertDelegate<string, List<GameDetails>> convertJSONToListGameDetailsDelegate) :
            base(
                getStringDataAsyncDelegate,
                convertJSONToListGameDetailsDelegate)
        {
            // ...
        }
    }
}