using System.Collections.Generic;
using System.IO;
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
    public class ItemizeAllUpdatedProductFilesAsyncDelegate : IItemizeAllAsyncDelegate<string>
    {
        private readonly ICompleteDelegate completeDelegate;
        private readonly IGetDataAsyncDelegate<Models.GameDetails, long> getGameDetailsByIdAsyncDelegate;
        private readonly IItemizeAllAsyncDelegate<long> itemizeAllUpdatedAsyncDelegate;
        private readonly IItemizeAsyncDelegate<Models.GameDetails, string> itemizeGameDetailsDirectoriesAsyncDelegate;
        private readonly ISetProgressDelegate setProgressDelegate;
        private readonly IStartDelegate startDelegate;

        [Dependencies(
            typeof(ItemizeAllUpdatedAsyncDelegate),
            typeof(GetGameDetailsByIdAsyncDelegate),
            typeof(ItemizeGameDetailsDirectoriesAsyncDelegate),
            typeof(StartDelegate),
            typeof(SetProgressDelegate),
            typeof(CompleteDelegate))]
        public ItemizeAllUpdatedProductFilesAsyncDelegate(
            IItemizeAllAsyncDelegate<long> itemizeAllUpdatedAsyncDelegate,
            IGetDataAsyncDelegate<Models.GameDetails, long> getGameDetailsByIdAsyncDelegate,
            IItemizeAsyncDelegate<Models.GameDetails, string> itemizeGameDetailsDirectoriesAsyncDelegate,
            IStartDelegate startDelegate,
            ISetProgressDelegate setProgressDelegate,
            ICompleteDelegate completeDelegate)
        {
            this.itemizeAllUpdatedAsyncDelegate = itemizeAllUpdatedAsyncDelegate;
            this.getGameDetailsByIdAsyncDelegate = getGameDetailsByIdAsyncDelegate;
            this.itemizeGameDetailsDirectoriesAsyncDelegate = itemizeGameDetailsDirectoriesAsyncDelegate;
            this.startDelegate = startDelegate;
            this.setProgressDelegate = setProgressDelegate;
            this.completeDelegate = completeDelegate;
        }

        public async IAsyncEnumerable<string> ItemizeAllAsync()
        {
            startDelegate.Start("Enumerate updated productFiles");

            await foreach (var id in itemizeAllUpdatedAsyncDelegate.ItemizeAllAsync())
            {
                var gameDetails = await getGameDetailsByIdAsyncDelegate.GetDataAsync(id);

                setProgressDelegate.SetProgress();

                var gameDetailsDirectories =
                    await itemizeGameDetailsDirectoriesAsyncDelegate.ItemizeAsync(
                        gameDetails);

                foreach (var gameDetailDirectory in gameDetailsDirectories)
                foreach (var updatedFile in Directory.EnumerateFiles(gameDetailDirectory))
                    yield return updatedFile;
            }

            completeDelegate.Complete();
        }
    }
}