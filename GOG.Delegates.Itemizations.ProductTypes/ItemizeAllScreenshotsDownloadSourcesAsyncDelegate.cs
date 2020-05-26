using System.Collections.Generic;
using System.IO;
using System.Linq;
using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Activities;
using SecretSauce.Delegates.Activities.Interfaces;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Conversions.Uris;
using SecretSauce.Delegates.Itemizations.Interfaces;
using SecretSauce.Delegates.Itemizations.ProductTypes;
using SecretSauce.Delegates.Values.Directories.ProductTypes;
using SecretSauce.Delegates.Values.Interfaces;

namespace GOG.Delegates.Itemizations.ProductTypes
{
    public class ItemizeAllScreenshotsDownloadSourcesAsyncDelegate : IItemizeAllAsyncDelegate<(long, IList<string>)>
    {
        private readonly ICompleteDelegate completeDelegate;
        private readonly IConvertDelegate<string, string> convertScreenshotsUriTemplateToUriDelegate;
        private readonly IItemizeAllAsyncDelegate<ProductScreenshots> itemizeAllProductScreenshotsAsyncDelegate;
        private readonly IGetValueDelegate<string, string> screenshotsDirectoryDelegate;
        private readonly ISetProgressDelegate setProgressDelegate;
        private readonly IStartDelegate startDelegate;

        [Dependencies(
            typeof(ItemizeAllProductScreenshotsAsyncDelegate),
            typeof(ConvertScreenshotsUriTemplateToUriDelegate),
            typeof(GetScreenshotsDirectoryDelegate),
            typeof(StartDelegate),
            typeof(SetProgressDelegate),
            typeof(CompleteDelegate))]
        public ItemizeAllScreenshotsDownloadSourcesAsyncDelegate(
            IItemizeAllAsyncDelegate<ProductScreenshots> itemizeAllProductScreenshotsAsyncDelegate,
            IConvertDelegate<string, string> convertScreenshotsUriTemplateToUriDelegate,
            IGetValueDelegate<string, string> screenshotsDirectoryDelegate,
            IStartDelegate startDelegate,
            ISetProgressDelegate setProgressDelegate,
            ICompleteDelegate completeDelegate)
        {
            this.itemizeAllProductScreenshotsAsyncDelegate = itemizeAllProductScreenshotsAsyncDelegate;
            this.convertScreenshotsUriTemplateToUriDelegate = convertScreenshotsUriTemplateToUriDelegate;
            this.screenshotsDirectoryDelegate = screenshotsDirectoryDelegate;
            this.startDelegate = startDelegate;
            this.setProgressDelegate = setProgressDelegate;
            this.completeDelegate = completeDelegate;
        }

        public async IAsyncEnumerable<(long, IList<string>)> ItemizeAllAsync()
        {
            startDelegate.Start("Process screenshots updates");

            await foreach (var productScreenshots in itemizeAllProductScreenshotsAsyncDelegate.ItemizeAllAsync())
            {
                if (productScreenshots == null)
                    // await statusController.WarnAsync(processProductsScreenshotsTask, $"Product {productScreenshots.Id} doesn't have screenshots");
                    continue;

                setProgressDelegate.SetProgress();

                var currentProductScreenshotSources = new List<string>();

                foreach (var uri in productScreenshots.Uris)
                {
                    var sourceUri = convertScreenshotsUriTemplateToUriDelegate.Convert(uri);
                    var destinationUri = Path.Combine(
                        screenshotsDirectoryDelegate.GetValue(string.Empty),
                        Path.GetFileName(sourceUri));

                    if (File.Exists(destinationUri)) continue;

                    currentProductScreenshotSources.Add(sourceUri);
                }

                if (currentProductScreenshotSources.Any())
                    yield return (productScreenshots.Id, currentProductScreenshotSources);
            }

            completeDelegate.Complete();
        }
    }
}