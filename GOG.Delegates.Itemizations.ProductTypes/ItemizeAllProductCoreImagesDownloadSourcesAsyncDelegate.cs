using System.Collections.Generic;
using Models.ProductTypes;
using SecretSauce.Delegates.Activities.Interfaces;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Itemizations.Interfaces;
using SecretSauce.Delegates.Values.Interfaces;

namespace GOG.Delegates.Itemizations.ProductTypes
{
    public abstract class ItemizeAllProductCoreImagesDownloadSourcesAsyncDelegate<T> :
        IItemizeAllAsyncDelegate<(long, IList<string>)>
        where T : ProductCore
    {
        private readonly ICompleteDelegate completeDelegate;
        private readonly IConvertDelegate<string, string> convertImagesUriTemplateToUriDelegate;
        private readonly IGetDataAsyncDelegate<T, long> getDataByIdAsyncDelegate;
        private readonly IGetValueDelegate<string, T> getImageUriDelegate;
        private readonly IItemizeAllAsyncDelegate<long> itemizeAllUpdatedAsyncDelegate;
        private readonly ISetProgressDelegate setProgressDelegate;
        private readonly IStartDelegate startDelegate;

        protected ItemizeAllProductCoreImagesDownloadSourcesAsyncDelegate(
            IItemizeAllAsyncDelegate<long> itemizeAllUpdatedAsyncDelegate,
            IGetDataAsyncDelegate<T, long> getDataByIdAsyncDelegate,
            IConvertDelegate<string, string> convertImagesUriTemplateToUriDelegate,
            IGetValueDelegate<string, T> getImageUriDelegate,
            IStartDelegate startDelegate,
            ISetProgressDelegate setProgressDelegate,
            ICompleteDelegate completeDelegate)
        {
            this.itemizeAllUpdatedAsyncDelegate = itemizeAllUpdatedAsyncDelegate;
            this.getDataByIdAsyncDelegate = getDataByIdAsyncDelegate;
            this.convertImagesUriTemplateToUriDelegate = convertImagesUriTemplateToUriDelegate;
            this.getImageUriDelegate = getImageUriDelegate;
            this.startDelegate = startDelegate;
            this.setProgressDelegate = setProgressDelegate;
            this.completeDelegate = completeDelegate;
        }

        public async IAsyncEnumerable<(long, IList<string>)> ItemizeAllAsync()
        {
            startDelegate.Start("Get download sources");

            await foreach (var id in itemizeAllUpdatedAsyncDelegate.ItemizeAllAsync())
            {
                setProgressDelegate.SetProgress();

                var productCore = await getDataByIdAsyncDelegate.GetDataAsync(id);

                // not all updated products can be found with all dataControllers
                if (productCore == null) continue;

                var imageSources = new List<string>
                {
                    convertImagesUriTemplateToUriDelegate.Convert(
                        getImageUriDelegate.GetValue(productCore))
                };

                yield return (id, imageSources);
            }

            completeDelegate.Complete();
        }
    }
}