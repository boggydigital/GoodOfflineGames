using System.Collections.Generic;
using System.Threading.Tasks;
using Attributes;
using GOG.Delegates.Data.Network;
using GOG.Delegates.Itemizations;
using GOG.Delegates.Itemizations.ProductTypes;
using GOG.Models;
using Models.ProductTypes;
using SecretSauce.Delegates.Activities;
using SecretSauce.Delegates.Activities.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Itemizations.Interfaces;
using SecretSauce.Delegates.Values.Interfaces;
using SecretSauce.Delegates.Values.Uris.ProductTypes;

namespace GOG.Delegates.Data.Models.ProductTypes
{
    public class GetProductScreenshotsByProductAsyncDelegate : IGetDataAsyncDelegate<ProductScreenshots, Product>
    {
        private readonly ICompleteDelegate completeDelegate;
        private readonly IGetValueDelegate<string, string> getUpdateUriDelegate;
        private readonly IGetDataAsyncDelegate<string, string> getUriDataAsyncDelegate;
        private readonly IItemizeDelegate<string, string> itemizeScreenshotsDelegates;

        private readonly IStartDelegate startDelegate;

        [Dependencies(
            typeof(GetScreenshotsUpdateUriDelegate),
            typeof(GetUriDataPolitelyAsyncDelegate),
            typeof(ItemizeScreenshotsDelegate),
            typeof(StartDelegate),
            typeof(CompleteDelegate))]
        public GetProductScreenshotsByProductAsyncDelegate(
            IGetValueDelegate<string, string> getUpdateUriDelegate,
            IGetDataAsyncDelegate<string, string> getUriDataAsyncDelegate,
            IItemizeDelegate<string, string> itemizeScreenshotsDelegates,
            IStartDelegate startDelegate,
            ICompleteDelegate completeDelegate)
        {
            this.getUpdateUriDelegate = getUpdateUriDelegate;
            this.getUriDataAsyncDelegate = getUriDataAsyncDelegate;
            this.itemizeScreenshotsDelegates = itemizeScreenshotsDelegates;
            this.startDelegate = startDelegate;
            this.completeDelegate = completeDelegate;
        }

        public async Task<ProductScreenshots> GetDataAsync(Product product)
        {
            startDelegate.Start("Request product page containing screenshots information");

            var productPageUri = string.Format(
                getUpdateUriDelegate.GetValue(string.Empty),
                product.Url);

            var productPageContent = await getUriDataAsyncDelegate.GetDataAsync(
                productPageUri);

            completeDelegate.Complete();

            startDelegate.Start("Exract screenshots from the page");
            var extractedProductScreenshots = itemizeScreenshotsDelegates.Itemize(
                productPageContent);

            if (extractedProductScreenshots == null) return null;

            var productScreenshots = new ProductScreenshots
            {
                Id = product.Id,
                Title = product.Title,
                Uris = new List<string>(extractedProductScreenshots)
            };
            completeDelegate.Complete();

            return productScreenshots;
        }
    }
}