using System.Collections.Generic;
using Attributes;
using GOG.Delegates.Data.Models.ProductTypes;
using GOG.Delegates.Itemizations.ProductTypes;
using GOG.Models;
using Models.ProductTypes;
using SecretSauce.Delegates.Activities;
using SecretSauce.Delegates.Activities.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Models.ProductTypes;
using SecretSauce.Delegates.Itemizations.Interfaces;
using SecretSauce.Delegates.Values.Directories.ProductTypes;
using SecretSauce.Delegates.Values.Interfaces;

namespace GOG.Delegates.Server.UpdateDownloads
{
    [ApiEndpoint(Method = "updatedownloads", Collection = "productimages")]
    public class UpdateProductImagesDownloadsAsyncDelegate :
        UpdateDownloadsAsyncDelegate<ProductImage>
    {
        [Dependencies(
            typeof(ItemizeAllProductImagesDownloadSourcesAsyncDelegate),
            typeof(GetProductImagesDirectoryDelegate),
            typeof(GetProductByIdAsyncDelegate),
            typeof(GetAccountProductByIdAsyncDelegate),
            typeof(GetProductDownloadsByIdAsyncDelegate),
            typeof(UpdateProductDownloadsAsyncDelegate),
            typeof(CommitProductDownloadsAsyncDelegate),
            typeof(StartDelegate),
            typeof(SetProgressDelegate),
            typeof(CompleteDelegate))]
        public UpdateProductImagesDownloadsAsyncDelegate(
            IItemizeAllAsyncDelegate<(long, IList<string>)> itemizeAllProductImagesDownloadSourcesAsyncDelegate,
            IGetValueDelegate<string, string> getProductImagesDirectoryDelegate,
            IGetDataAsyncDelegate<Product, long> getProductByIdAsyncDelegate,
            IGetDataAsyncDelegate<AccountProduct, long> getAccountProductByIdAsyncDelegate,
            IGetDataAsyncDelegate<ProductDownloads, long> getProductDownloadsByIdAsyncDelegate,
            IUpdateAsyncDelegate<ProductDownloads> updateProductDownloadsAsyncDelegate,
            ICommitAsyncDelegate commitProductDownloadsAsyncDelegate,
            IStartDelegate startDelegate,
            ISetProgressDelegate setProgressDelegate,
            ICompleteDelegate completeDelegate) :
            base(
                itemizeAllProductImagesDownloadSourcesAsyncDelegate,
                getProductImagesDirectoryDelegate,
                getProductByIdAsyncDelegate,
                getAccountProductByIdAsyncDelegate,
                getProductDownloadsByIdAsyncDelegate,
                updateProductDownloadsAsyncDelegate,
                commitProductDownloadsAsyncDelegate,
                startDelegate,
                setProgressDelegate,
                completeDelegate)
        {
            // ...
        }
    }
}