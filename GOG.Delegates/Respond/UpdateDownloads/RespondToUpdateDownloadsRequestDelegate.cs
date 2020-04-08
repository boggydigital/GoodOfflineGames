﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using Interfaces.Delegates.GetDirectory;
using Interfaces.Delegates.Respond;
using Interfaces.Controllers.Data;
using Interfaces.Delegates.Activities;
using GOG.Interfaces.Delegates.GetDownloadSources;
using Models.ProductTypes;
using GOG.Models;

// TODO: Should this be just update if collections don't overlap?
namespace GOG.Delegates.Respond.UpdateDownloads
{
    public abstract class RespondToUpdateDownloadsRequestDelegate<Type> : IRespondAsyncDelegate
        where Type : ProductCore
    {
        private readonly IGetDownloadSourcesAsyncDelegate getDownloadSourcesAsyncDelegate;
        private readonly IGetDirectoryDelegate getDirectoryDelegate;
        private readonly IDataController<ProductDownloads> productDownloadsDataController;
        private readonly IDataController<AccountProduct> accountProductsDataController;
        private readonly IDataController<Product> productsDataController;
        private readonly IStartDelegate startDelegate;
        private readonly ISetProgressDelegate setProgressDelegate;
        private readonly ICompleteDelegate completeDelegate;

        public RespondToUpdateDownloadsRequestDelegate(
            IGetDownloadSourcesAsyncDelegate getDownloadSourcesAsyncDelegate,
            IGetDirectoryDelegate getDirectoryDelegate,
            IDataController<ProductDownloads> productDownloadsDataController,
            IDataController<AccountProduct> accountProductsDataController,
            IDataController<Product> productsDataController,
            IStartDelegate startDelegate,
            ISetProgressDelegate setProgressDelegate,
            ICompleteDelegate completeDelegate)
        {
            this.getDownloadSourcesAsyncDelegate = getDownloadSourcesAsyncDelegate;
            this.getDirectoryDelegate = getDirectoryDelegate;
            this.productDownloadsDataController = productDownloadsDataController;
            this.accountProductsDataController = accountProductsDataController;
            this.productsDataController = productsDataController;
            this.startDelegate = startDelegate;
            this.setProgressDelegate = setProgressDelegate;
            this.completeDelegate = completeDelegate;
        }

        public async Task RespondAsync(IDictionary<string, IEnumerable<string>> parameters)
        {
            startDelegate.Start(
                $"Update {typeof(Type)} downloads");

            startDelegate.Start($"Get {typeof(Type)} download sources");
            var downloadSources = await getDownloadSourcesAsyncDelegate.GetDownloadSourcesAsync();
            completeDelegate.Complete();

            startDelegate.Start("Update individual downloads");
            foreach (var downloadSource in downloadSources)
            {
                // don't perform expensive updates if there are no actual sources
                if (downloadSource.Value != null &&
                    downloadSource.Value.Count == 0) continue;

                var id = downloadSource.Key;

                ProductCore product = await productsDataController.GetByIdAsync(id);

                if (product == null)
                {
                    product = await accountProductsDataController.GetByIdAsync(id);

                    if (product == null)
                        // await statusController.WarnAsync(
                        //     updateDownloadsTask,
                        //     $"Downloads are scheduled for the product/account product {id} that doesn't exist");
                        continue;
                }

                setProgressDelegate.SetProgress();

                var productDownloads = await productDownloadsDataController.GetByIdAsync(product.Id);
                if (productDownloads == null)
                    productDownloads = new ProductDownloads
                    {
                        Id = product.Id,
                        Title = product.Title,
                        Downloads = new List<ProductDownloadEntry>()
                    };

                // purge existing downloads for this download type as we'll always be scheduling all files we need to download
                // and don't want to carry over any previously scheduled files that might not be relevant anymore
                // (e.g. files that were scheduled, but never downloaded and then removed from data files)
                var existingDownloadsOfType = productDownloads.Downloads.FindAll(
                    d => d.Type == typeof(Type).ToString()).ToArray();
                foreach (var download in existingDownloadsOfType)
                    productDownloads.Downloads.Remove(download);

                startDelegate.Start("Schedule new downloads");

                foreach (var source in downloadSource.Value)
                {
                    var destinationDirectory = getDirectoryDelegate?.GetDirectory(source);

                    var scheduledDownloadEntry = new ProductDownloadEntry
                    {
                        Type = typeof(Type).ToString(),
                        SourceUri = source,
                        Destination = destinationDirectory
                    };

                    var destinationUri = Path.Combine(
                        destinationDirectory,
                        Path.GetFileName(source));

                    // we won't schedule downloads for the already existing files
                    // we won't be able to resolve filename for productFiles, but that should cut off 
                    // number of images we constantly try to redownload
                    if (File.Exists(destinationUri)) continue;

                    productDownloads.Downloads.Add(scheduledDownloadEntry);
                }

                await productDownloadsDataController.UpdateAsync(productDownloads);

                completeDelegate.Complete();
            }

            completeDelegate.Complete();

            completeDelegate.Complete();
        }
    }
}