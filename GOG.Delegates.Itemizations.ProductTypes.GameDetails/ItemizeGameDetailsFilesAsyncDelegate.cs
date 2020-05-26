using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Attributes;
using SecretSauce.Delegates.Activities;
using SecretSauce.Delegates.Activities.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Models.ProductTypes;
using SecretSauce.Delegates.Itemizations.Interfaces;
using SecretSauce.Delegates.Values.Interfaces;
using SecretSauce.Delegates.Values.Paths.JSON;

namespace GOG.Delegates.Itemizations.ProductTypes.GameDetails
{
    public class ItemizeGameDetailsFilesAsyncDelegate : IItemizeAsyncDelegate<Models.GameDetails, string>
    {
        private readonly ICompleteDelegate completeDelegate;
        private readonly IGetValueDelegate<string, (string Directory, string Filename)> getPathDelegate;
        private readonly IGetDataAsyncDelegate<string, (long Id, string Source)> getRouteDataAsyncDelegate;
        private readonly IItemizeAsyncDelegate<Models.GameDetails, string> itemizeGameDetailsManualUrlsDelegate;
        private readonly IStartDelegate startDelegate;

        [Dependencies(
            typeof(ItemizeGameDetailsManualUrlsAsyncDelegate),
            typeof(GetRouteDataAsyncDelegate),
            typeof(GetGameDetailsFilesPathDelegate),
            typeof(StartDelegate),
            typeof(CompleteDelegate))]
        public ItemizeGameDetailsFilesAsyncDelegate(
            IItemizeAsyncDelegate<Models.GameDetails, string> itemizeGameDetailsManualUrlsDelegate,
            IGetDataAsyncDelegate<string, (long Id, string Source)> getRouteDataAsyncDelegate,
            IGetValueDelegate<string, (string Directory, string Filename)> getPathDelegate,
            IStartDelegate startDelegate,
            ICompleteDelegate completeDelegate)
        {
            this.itemizeGameDetailsManualUrlsDelegate = itemizeGameDetailsManualUrlsDelegate;
            this.getPathDelegate = getPathDelegate;
            this.getRouteDataAsyncDelegate = getRouteDataAsyncDelegate;
            this.startDelegate = startDelegate;
            this.completeDelegate = completeDelegate;
        }

        public async Task<IEnumerable<string>> ItemizeAsync(Models.GameDetails gameDetails)
        {
            startDelegate.Start("Enumerate game details files");

            var gameDetailsFiles = new List<string>();

            var gameDetailsManualUrls = await itemizeGameDetailsManualUrlsDelegate.ItemizeAsync(gameDetails);
            var gameDetailsManualUrlsCount = gameDetailsManualUrls.Count();
            var gameDetailsResolvedUris = new List<string>();
            foreach (var manualUrl in gameDetailsManualUrls)
                gameDetailsResolvedUris.Add(
                    await getRouteDataAsyncDelegate.GetDataAsync((
                        gameDetails.Id,
                        manualUrl)));

            // that means that routes information is incomplete and 
            // it's not possible to map manualUrls to resolvedUrls
            if (gameDetailsManualUrlsCount != gameDetailsResolvedUris.Count)
            {
                completeDelegate.Complete();
                throw new ArgumentException(
                    $"Product {gameDetails.Id} resolvedUris count doesn't match manualUrls count");
            }

            for (var ii = 0; ii < gameDetailsResolvedUris.Count; ii++)
            {
                // since we don't download all languages and operating systems 
                // we don't have routes for each and every gameDetails uri
                // however the ones we have should represent expected files for that product
                if (string.IsNullOrEmpty(gameDetailsResolvedUris[ii]))
                    continue;

                //var localFileUri = Path.Combine(
                //    GetValueDelegate.GetValue(gameDetailsManualUrls.ElementAt(ii)),
                //getFilenameDelegate.GetFilename(gameDetailsResolvedUris[ii]));

                var localFilePath = getPathDelegate.GetValue((
                    gameDetailsManualUrls.ElementAt(ii),
                    gameDetailsResolvedUris[ii]));

                gameDetailsFiles.Add(localFilePath);
            }

            completeDelegate.Complete();

            if (gameDetailsManualUrlsCount != gameDetailsFiles.Count)
                throw new ArgumentException($"Product {gameDetails.Id} files count doesn't match manualUrls count");

            return gameDetailsFiles;
        }
    }
}