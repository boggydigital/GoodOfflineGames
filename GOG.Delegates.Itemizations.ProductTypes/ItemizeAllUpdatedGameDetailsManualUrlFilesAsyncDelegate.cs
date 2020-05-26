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
    public class ItemizeAllUpdatedGameDetailsManualUrlFilesAsyncDelegate : IItemizeAllAsyncDelegate<string>
    {
        private readonly ICompleteDelegate completeDelegate;
        private readonly IGetDataAsyncDelegate<Models.GameDetails, long> getGameDetailsByIdAsyncDelegate;
        private readonly IItemizeAllAsyncDelegate<long> itemizeAllUpdatedAsyncDelegate;
        private readonly IItemizeAsyncDelegate<Models.GameDetails, string> itemizeGameDetailsFilesAsyncDelegate;
        private readonly ISetProgressDelegate setProgressDelegate;
        private readonly IStartDelegate startDelegate;

        [Dependencies(
            typeof(ItemizeAllUpdatedAsyncDelegate),
            typeof(GetGameDetailsByIdAsyncDelegate),
            typeof(ItemizeGameDetailsFilesAsyncDelegate),
            typeof(StartDelegate),
            typeof(SetProgressDelegate),
            typeof(CompleteDelegate))]
        public ItemizeAllUpdatedGameDetailsManualUrlFilesAsyncDelegate(
            IItemizeAllAsyncDelegate<long> itemizeAllUpdatedAsyncDelegate,
            IGetDataAsyncDelegate<Models.GameDetails, long> getGameDetailsByIdAsyncDelegate,
            IItemizeAsyncDelegate<Models.GameDetails, string> itemizeGameDetailsFilesAsyncDelegate,
            IStartDelegate startDelegate,
            ISetProgressDelegate setProgressDelegate,
            ICompleteDelegate completeDelegate)
        {
            this.itemizeAllUpdatedAsyncDelegate = itemizeAllUpdatedAsyncDelegate;
            this.getGameDetailsByIdAsyncDelegate = getGameDetailsByIdAsyncDelegate;
            this.itemizeGameDetailsFilesAsyncDelegate = itemizeGameDetailsFilesAsyncDelegate;
            this.startDelegate = startDelegate;
            this.setProgressDelegate = setProgressDelegate;
            this.completeDelegate = completeDelegate;
        }

        public async IAsyncEnumerable<string> ItemizeAllAsync()
        {
            startDelegate.Start("Enumerate updated gameDetails files");

            await foreach (var id in itemizeAllUpdatedAsyncDelegate.ItemizeAllAsync())
            {
                var gameDetails = await getGameDetailsByIdAsyncDelegate.GetDataAsync(id);

                setProgressDelegate.SetProgress();

                foreach (var gameDetailsFile in await itemizeGameDetailsFilesAsyncDelegate.ItemizeAsync(
                    gameDetails))
                    yield return gameDetailsFile;
            }

            completeDelegate.Complete();
        }
    }
}