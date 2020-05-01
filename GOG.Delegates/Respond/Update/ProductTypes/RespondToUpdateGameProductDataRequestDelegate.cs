﻿using Interfaces.Delegates.Convert;
using Interfaces.Delegates.GetValue;
using Interfaces.Delegates.Itemize;
using Interfaces.Delegates.Data;
using Interfaces.Delegates.Activities;
using Attributes;
using GOG.Interfaces.Delegates.GetDeserialized;
using GOG.Models;
using Delegates.GetValue.Uri.ProductTypes;
using Delegates.Activities;

namespace GOG.Delegates.Respond.Update.ProductTypes
{
    [RespondsToRequests(Method = "update", Collection = "gameproductdata")]
    public class RespondToUpdateGameProductDataRequestDelegate :
        RespondToUpdateMasterDetailsRequestDelegate<GameProductData, Product>
    {
        [Dependencies(
            typeof(GetGameProductDataUpdateUriDelegate),
            typeof(GOG.Delegates.Convert.UpdateIdentity.ConvertProductToGameProductDataUpdateIdentityDelegate),
            typeof(GOG.Delegates.Data.Models.ProductTypes.UpdateGameProductDataAsyncDelegate),
            typeof(GOG.Delegates.Data.Models.ProductTypes.CommitGameProductDataAsyncDelegate),
            typeof(GOG.Delegates.Itemize.MasterDetail.ItemizeAllProductsGameProductDataGapsAsyncDelegate),
            typeof(GOG.Delegates.GetDeserialized.ProductTypes.GetDeserializedGameProductDataAsyncDelegate),
            typeof(StartDelegate),
            typeof(SetProgressDelegate),
            typeof(CompleteDelegate))]
        public RespondToUpdateGameProductDataRequestDelegate(
            IGetValueDelegate<string> getGameProductDataUpdateUriDelegate,
            IConvertDelegate<Product, string> convertProductToGameProductDataUpdateIdentityDelegate,
            IUpdateAsyncDelegate<GameProductData> updateGameProductDataAsyncDelegate,
            ICommitAsyncDelegate commitGameProductDataAsyncDelegate,
            IItemizeAllAsyncDelegate<Product> itemizeAllProductsGameProductDataGapsAsyncDelegate,
            IGetDeserializedAsyncDelegate<GameProductData> getDeserializedGameProductDataAsyncDelegate,
            IStartDelegate startDelegate,
            ISetProgressDelegate setProgressDelegate,
            ICompleteDelegate completeDelegate) :
            base(
                getGameProductDataUpdateUriDelegate,
                convertProductToGameProductDataUpdateIdentityDelegate,
                updateGameProductDataAsyncDelegate,
                commitGameProductDataAsyncDelegate,
                itemizeAllProductsGameProductDataGapsAsyncDelegate,
                getDeserializedGameProductDataAsyncDelegate,
                startDelegate,
                setProgressDelegate,
                completeDelegate,
                null)
        {
            // ...
        }
    }
}