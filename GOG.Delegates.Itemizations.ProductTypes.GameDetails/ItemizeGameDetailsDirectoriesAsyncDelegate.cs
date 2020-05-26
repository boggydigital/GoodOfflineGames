using System.Collections.Generic;
using System.Threading.Tasks;
using Attributes;
using SecretSauce.Delegates.Itemizations.Interfaces;
using SecretSauce.Delegates.Values.Directories.ProductTypes;
using SecretSauce.Delegates.Values.Interfaces;

namespace GOG.Delegates.Itemizations.ProductTypes.GameDetails
{
    public class ItemizeGameDetailsDirectoriesAsyncDelegate : IItemizeAsyncDelegate<Models.GameDetails, string>
    {
        private readonly IGetValueDelegate<string, string> getDirectoryDelegate;
        private readonly IItemizeAsyncDelegate<Models.GameDetails, string> itemizeGameDetailsManualUrlsAsyncDelegate;

        [Dependencies(
            typeof(ItemizeGameDetailsManualUrlsAsyncDelegate),
            typeof(GetProductFilesDirectoryDelegate))]
        public ItemizeGameDetailsDirectoriesAsyncDelegate(
            IItemizeAsyncDelegate<Models.GameDetails, string> itemizeGameDetailsManualUrlsAsyncDelegate,
            IGetValueDelegate<string, string> getDirectoryDelegate)
        {
            this.itemizeGameDetailsManualUrlsAsyncDelegate = itemizeGameDetailsManualUrlsAsyncDelegate;
            this.getDirectoryDelegate = getDirectoryDelegate;
        }

        public async Task<IEnumerable<string>> ItemizeAsync(Models.GameDetails gameDetails)
        {
            var gameDetailsDirectories = new List<string>();

            foreach (var manualUrl in await itemizeGameDetailsManualUrlsAsyncDelegate.ItemizeAsync(gameDetails))
            {
                var directory = getDirectoryDelegate.GetValue(manualUrl);

                if (!gameDetailsDirectories.Contains(directory))
                    gameDetailsDirectories.Add(directory);
            }

            return gameDetailsDirectories;
        }
    }
}