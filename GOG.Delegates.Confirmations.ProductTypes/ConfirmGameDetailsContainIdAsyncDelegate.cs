using Attributes;
using GOG.Delegates.Data.Models.ProductTypes;
using GOG.Models;
using SecretSauce.Delegates.Confirmations;
using SecretSauce.Delegates.Data.Interfaces;

namespace GOG.Delegates.Confirmations.ProductTypes
{
    public class ConfirmGameDetailsContainIdAsyncDelegate : ConfirmDataContainsIdAsyncDelegate<GameDetails>
    {
        [Dependencies(
            typeof(GetGameDetailsByIdAsyncDelegate))]
        public ConfirmGameDetailsContainIdAsyncDelegate(
            IGetDataAsyncDelegate<GameDetails, long> getGameDetailsByIdAsyncDelegate) :
            base(getGameDetailsByIdAsyncDelegate)
        {
            // ...
        }
    }
}