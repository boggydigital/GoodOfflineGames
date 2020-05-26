using System.Collections.Generic;
using Attributes;
using GOG.Delegates.Data.Storage.ProductTypes;
using GOG.Delegates.Itemizations.ProductTypes.GameDetails;
using SecretSauce.Delegates.Activities;
using SecretSauce.Delegates.Activities.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Itemizations.Interfaces;

namespace GOG.Delegates.Itemizations.ProductTypes
{
    public class ItemizeAllGameDetailsDirectoriesAsyncDelegate : IItemizeAllAsyncDelegate<string>
    {
        private readonly ICompleteDelegate completeDelegate;
        private readonly IGetDataAsyncDelegate<IList<Models.GameDetails>, string> getGameDetailsAsyncDelegate;
        private readonly IItemizeAsyncDelegate<Models.GameDetails, string> itemizeGameDetailsDirectoriesAsyncDelegate;
        private readonly ISetProgressDelegate setProgressDelegate;
        private readonly IStartDelegate startDelegate;

        [Dependencies(
            typeof(GetStoredListGameDetailsDataAsyncDelegate),
            typeof(ItemizeGameDetailsDirectoriesAsyncDelegate),
            typeof(StartDelegate),
            typeof(SetProgressDelegate),
            typeof(CompleteDelegate))]
        public ItemizeAllGameDetailsDirectoriesAsyncDelegate(
            IGetDataAsyncDelegate<IList<Models.GameDetails>, string> getGameDetailsAsyncDelegate,
            IItemizeAsyncDelegate<Models.GameDetails, string> itemizeGameDetailsDirectoriesAsyncDelegate,
            IStartDelegate startDelegate,
            ISetProgressDelegate setProgressDelegate,
            ICompleteDelegate completeDelegate)
        {
            this.getGameDetailsAsyncDelegate = getGameDetailsAsyncDelegate;
            this.itemizeGameDetailsDirectoriesAsyncDelegate = itemizeGameDetailsDirectoriesAsyncDelegate;
            this.startDelegate = startDelegate;
            this.setProgressDelegate = setProgressDelegate;
            this.completeDelegate = completeDelegate;
        }

        public async IAsyncEnumerable<string> ItemizeAllAsync()
        {
            startDelegate.Start("Enumerate gameDetails directories");

            foreach (var gameDetails in await getGameDetailsAsyncDelegate.GetDataAsync(string.Empty))
            {
                setProgressDelegate.SetProgress();

                foreach (var directory in await itemizeGameDetailsDirectoriesAsyncDelegate.ItemizeAsync(
                    gameDetails))
                    yield return directory;
            }

            completeDelegate.Complete();
        }
    }
}