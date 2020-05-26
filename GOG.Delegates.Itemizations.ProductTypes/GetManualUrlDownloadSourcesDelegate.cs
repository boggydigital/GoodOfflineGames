using System.Collections.Generic;
using Attributes;
using GOG.Delegates.Data.Models.ProductTypes;
using GOG.Delegates.Itemizations.ProductTypes.GameDetails;
using SecretSauce.Delegates.Activities;
using SecretSauce.Delegates.Activities.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Itemizations.Interfaces;
using SecretSauce.Delegates.Itemizations.ProductTypes;

namespace GOG.Delegates.Itemizations.ProductTypes
{
    public class ItemizeAllManualUrlDownloadSourcesAsyncDelegate :
        IItemizeAllAsyncDelegate<(long, IList<string>)>
    {
        private readonly ICompleteDelegate completeDelegate;
        private readonly IGetDataAsyncDelegate<Models.GameDetails, long> getGameDetailsByIdAsyncDelegate;
        private readonly IItemizeAllAsyncDelegate<long> itemizeAllUpdatedAsyncDelegate;
        private readonly IItemizeAsyncDelegate<Models.GameDetails, string> itemizeGameDetailsManualUrlsAsyncController;
        private readonly ISetProgressDelegate setProgressDelegate;
        private readonly IStartDelegate startDelegate;

        [Dependencies(
            typeof(ItemizeAllUpdatedAsyncDelegate),
            typeof(GetGameDetailsByIdAsyncDelegate),
            typeof(ItemizeGameDetailsManualUrlsAsyncDelegate),
            typeof(StartDelegate),
            typeof(SetProgressDelegate),
            typeof(CompleteDelegate))]
        public ItemizeAllManualUrlDownloadSourcesAsyncDelegate(
            IItemizeAllAsyncDelegate<long> itemizeAllUpdatedAsyncDelegate,
            IGetDataAsyncDelegate<Models.GameDetails, long> getGameDetailsByIdAsyncDelegate,
            IItemizeAsyncDelegate<Models.GameDetails, string> itemizeGameDetailsManualUrlsAsyncController,
            IStartDelegate startDelegate,
            ISetProgressDelegate setProgressDelegate,
            ICompleteDelegate completeDelegate)
        {
            this.itemizeAllUpdatedAsyncDelegate = itemizeAllUpdatedAsyncDelegate;
            this.getGameDetailsByIdAsyncDelegate = getGameDetailsByIdAsyncDelegate;
            this.itemizeGameDetailsManualUrlsAsyncController = itemizeGameDetailsManualUrlsAsyncController;
            this.startDelegate = startDelegate;
            this.setProgressDelegate = setProgressDelegate;
            this.completeDelegate = completeDelegate;
        }

        public async IAsyncEnumerable<(long, IList<string>)> ItemizeAllAsync()
        {
            startDelegate.Start("Get download sources");

            await foreach (var id in itemizeAllUpdatedAsyncDelegate.ItemizeAllAsync())
            {
                setProgressDelegate.SetProgress();

                var gameDetails = await getGameDetailsByIdAsyncDelegate.GetDataAsync(id);

                yield return (
                    id,
                    new List<string>(
                        await itemizeGameDetailsManualUrlsAsyncController.ItemizeAsync(gameDetails)));
            }

            completeDelegate.Complete();
        }
    }
}