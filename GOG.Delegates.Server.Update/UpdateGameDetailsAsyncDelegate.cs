using Attributes;
using GOG.Delegates.Conversions.UpdateIdentity;
using GOG.Delegates.Conversions.UpdateIdentity.ProductTypes;
using GOG.Delegates.Data.Models.ProductTypes;
using GOG.Delegates.Itemizations.MasterDetail;
using GOG.Models;
using SecretSauce.Delegates.Activities;
using SecretSauce.Delegates.Activities.Interfaces;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Itemizations.Interfaces;
using SecretSauce.Delegates.Values.Interfaces;
using SecretSauce.Delegates.Values.Uris.ProductTypes;

namespace GOG.Delegates.Server.Update
{
    [ApiEndpoint(Method = "update", Collection = "gamedetails")]
    public class UpdateGameDetailsAsyncDelegate :
        UpdateMasterDetailsAsyncDelegate<GameDetails, AccountProduct>
    {
        [Dependencies(
            typeof(GetGameDetailsUpdateUriDelegate),
            typeof(ConvertAccountProductToGameDetailsUpdateIdentityDelegate),
            typeof(UpdateGameDetailsAsyncDelegate),
            typeof(CommitGameDetailsAsyncDelegate),
            typeof(ItemizeAllAccountProductsGameDetailsGapsAsyncDelegate),
            typeof(GetDeserializedGameDetailsAsyncDelegate),
            typeof(StartDelegate),
            typeof(SetProgressDelegate),
            typeof(CompleteDelegate))]
        public UpdateGameDetailsAsyncDelegate(
            IGetValueDelegate<string, string> getGameDetailsUpdateUriDelegate,
            IConvertDelegate<AccountProduct, string> convertAccountProductToGameDetailsUpdateIdentityDelegate,
            IUpdateAsyncDelegate<GameDetails> updateGameDetailsAsyncDelegate,
            ICommitAsyncDelegate commitGameDetailsAsyncDelegate,
            IItemizeAllAsyncDelegate<AccountProduct> itemizeAllAccountProductsGameDetailsGapsAsyncDelegate,
            IGetDataAsyncDelegate<GameDetails, string> getDeserializedGameDetailsAsyncDelegate,
            IStartDelegate startDelegate,
            ISetProgressDelegate setProgressDelegate,
            ICompleteDelegate completeDelegate) :
            base(
                getGameDetailsUpdateUriDelegate,
                convertAccountProductToGameDetailsUpdateIdentityDelegate,
                updateGameDetailsAsyncDelegate,
                commitGameDetailsAsyncDelegate,
                itemizeAllAccountProductsGameDetailsGapsAsyncDelegate,
                getDeserializedGameDetailsAsyncDelegate,
                startDelegate,
                setProgressDelegate,
                completeDelegate)
        {
            // ...
        }
    }
}