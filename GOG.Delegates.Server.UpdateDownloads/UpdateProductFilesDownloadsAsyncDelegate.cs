using System.Collections.Generic;
using Attributes;
using GOG.Delegates.Data.Models.ProductTypes;
using GOG.Delegates.Itemizations;
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
    [ApiEndpoint(Method = "updatedownloads", Collection = "productfiles")]
    public class UpdateProductFilesDownloadsAsyncDelegate :
        UpdateDownloadsAsyncDelegate<ProductFile>
    {
        [Dependencies(
            typeof(ItemizeAllManualUrlDownloadSourcesAsyncDelegate),
            typeof(GetProductFilesDirectoryDelegate),
            typeof(GetProductByIdAsyncDelegate),
            typeof(GetAccountProductByIdAsyncDelegate),
            typeof(GetProductDownloadsByIdAsyncDelegate),
            typeof(UpdateProductDownloadsAsyncDelegate),
            typeof(CommitProductDownloadsAsyncDelegate),
            typeof(StartDelegate),
            typeof(SetProgressDelegate),
            typeof(CompleteDelegate))]
        public UpdateProductFilesDownloadsAsyncDelegate(
            IItemizeAllAsyncDelegate<(long, IList<string>)> itemizeAllProductFilesDownloadSourcesAsyncDelegate,
            IGetValueDelegate<string, string> getProductFilesDirectoryDelegate,
            IGetDataAsyncDelegate<Product, long> getProductByIdAsyncDelegate,
            IGetDataAsyncDelegate<AccountProduct, long> getAccountProductByIdAsyncDelegate,
            IGetDataAsyncDelegate<ProductDownloads, long> getProductDownloadsByIdAsyncDelegate,
            IUpdateAsyncDelegate<ProductDownloads> updateProductDownloadsAsyncDelegate,
            ICommitAsyncDelegate commitProductDownloadsAsyncDelegate,
            IStartDelegate startDelegate,
            ISetProgressDelegate setProgressDelegate,
            ICompleteDelegate completeDelegate) :
            base(
                itemizeAllProductFilesDownloadSourcesAsyncDelegate,
                getProductFilesDirectoryDelegate,
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