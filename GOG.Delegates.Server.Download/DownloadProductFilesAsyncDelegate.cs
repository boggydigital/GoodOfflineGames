using Attributes;
using GOG.Delegates.Data.Models;
using GOG.Models;
using Models.ProductTypes;
using SecretSauce.Delegates.Activities;
using SecretSauce.Delegates.Activities.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Models.ProductTypes;
using SecretSauce.Delegates.Itemizations.Interfaces;
using SecretSauce.Delegates.Itemizations.ProductTypes;

namespace GOG.Delegates.Server.Download
{
    [ApiEndpoint(Method = "download", Collection = "productfiles")]
    public class DownloadProductFilesAsyncDelegate : DownloadAsyncDelegate<ProductFile>
    {
        [Dependencies(
            typeof(ItemizeAllProductDownloadsAsyncDelegate),
            typeof(UpdateProductDownloadsAsyncDelegate),
            typeof(DeleteProductDownloadsAsyncDelegate),
            typeof(GetManualUrlFileAsyncDelegate),
            typeof(StartDelegate),
            typeof(SetProgressDelegate),
            typeof(CompleteDelegate))]
        public DownloadProductFilesAsyncDelegate(
            IItemizeAllAsyncDelegate<ProductDownloads> itemizeAllProductDownloadsAsyncDelegate,
            IUpdateAsyncDelegate<ProductDownloads> updateProductDownloadsAsyncDelegate,
            IDeleteAsyncDelegate<ProductDownloads> deleteProductDownloadsAsyncDelegate,
            IGetDataAsyncDelegate<string, ProductFileDownloadManifest> getProductFileAsyncDelegate,
            IStartDelegate startDelegate,
            ISetProgressDelegate setProgressDelegate,
            ICompleteDelegate completeDelegate) :
            base(
                itemizeAllProductDownloadsAsyncDelegate,
                updateProductDownloadsAsyncDelegate,
                deleteProductDownloadsAsyncDelegate,
                getProductFileAsyncDelegate,
                startDelegate,
                setProgressDelegate,
                completeDelegate)
        {
            // ...
        }
    }
}