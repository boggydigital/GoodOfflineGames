﻿using Interfaces.Delegates.Convert;
using Interfaces.Delegates.GetValue;
using Interfaces.Delegates.Itemize;
using Interfaces.Delegates.Data;
using Interfaces.Delegates.Activities;
using Attributes;
using GOG.Interfaces.Delegates.GetDeserialized;
using GOG.Interfaces.Delegates.FillGaps;
using GOG.Models;

namespace GOG.Delegates.Respond.Update.ProductTypes
{
    [RespondsToRequests(Method = "update", Collection = "gamedetails")]
    public class RespondToUpdateGameDetailsRequestDelegate :
        RespondToUpdateMasterDetailsRequestDelegate<GameDetails, AccountProduct>
    {
        [Dependencies(
            "Delegates.GetValue.Uri.ProductTypes.GetGameDetailsUpdateUriDelegate,Delegates",
            "GOG.Delegates.Convert.UpdateIdentity.ConvertAccountProductToGameDetailsUpdateIdentityDelegate,GOG.Delegates",
            "GOG.Delegates.Data.Models.ProductTypes.UpdateGameDetailsAsyncDelegate,GOG.Delegates",
            "GOG.Delegates.Data.Models.ProductTypes.CommitGameDetailsAsyncDelegate,GOG.Delegates",
            "GOG.Delegates.Itemize.MasterDetail.ItemizeAllAccountProductsGameDetailsGapsAsyncDelegate,GOG.Delegates",
            "GOG.Delegates.GetDeserialized.ProductTypes.GetDeserializedGameDetailsAsyncDelegate,GOG.Delegates",
            "Delegates.Activities.StartDelegate,Delegates",
            "Delegates.Activities.SetProgressDelegate,Delegates",
            "Delegates.Activities.CompleteDelegate,Delegates",
            "GOG.Delegates.FillGaps.FillGameDetailsGapsDelegate,GOG.Delegates")]
        public RespondToUpdateGameDetailsRequestDelegate(
            IGetValueDelegate<string> getGameDetailsUpdateUriDelegate,
            IConvertDelegate<AccountProduct, string> convertAccountProductToGameDetailsUpdateIdentityDelegate,
            IUpdateAsyncDelegate<GameDetails> updateGameDetailsAsyncDelegate,
            ICommitAsyncDelegate commitGameDetailsAsyncDelegate,
            IItemizeAllAsyncDelegate<AccountProduct> itemizeAllAccountProductsGameDetailsGapsAsyncDelegate,
            IGetDeserializedAsyncDelegate<GameDetails> getDeserializedGameDetailsAsyncDelegate,
            IStartDelegate startDelegate,
            ISetProgressDelegate setProgressDelegate,
            ICompleteDelegate completeDelegate,
            IFillGapsDelegate<GameDetails, AccountProduct> fillGameDetailsGapsDelegate) :
            base(
                getGameDetailsUpdateUriDelegate,
                convertAccountProductToGameDetailsUpdateIdentityDelegate,
                updateGameDetailsAsyncDelegate,
                commitGameDetailsAsyncDelegate,
                itemizeAllAccountProductsGameDetailsGapsAsyncDelegate,
                getDeserializedGameDetailsAsyncDelegate,
                startDelegate,
                setProgressDelegate,
                completeDelegate,
                fillGameDetailsGapsDelegate)
        {
            // ...
        }
    }
}