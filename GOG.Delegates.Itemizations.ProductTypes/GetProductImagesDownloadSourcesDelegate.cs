using Attributes;
using GOG.Delegates.Data.Models.ProductTypes;
using GOG.Delegates.Values.Images;
using GOG.Delegates.Values.Images.ProductTypes;
using GOG.Models;
using SecretSauce.Delegates.Activities;
using SecretSauce.Delegates.Activities.Interfaces;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Conversions.Uris;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Itemizations.Interfaces;
using SecretSauce.Delegates.Itemizations.ProductTypes;
using SecretSauce.Delegates.Values.Interfaces;

namespace GOG.Delegates.Itemizations.ProductTypes
{
    public class ItemizeAllProductImagesDownloadSourcesAsyncDelegate :
        ItemizeAllProductCoreImagesDownloadSourcesAsyncDelegate<Product>
    {
        [Dependencies(
            typeof(ItemizeAllUpdatedAsyncDelegate),
            typeof(GetProductByIdAsyncDelegate),
            typeof(ConvertImagesUriTemplateToUriDelegate),
            typeof(GetProductImageUriDelegate),
            typeof(StartDelegate),
            typeof(SetProgressDelegate),
            typeof(CompleteDelegate))]
        public ItemizeAllProductImagesDownloadSourcesAsyncDelegate(
            IItemizeAllAsyncDelegate<long> itemizeAllUpdatedAsyncDelegate,
            IGetDataAsyncDelegate<Product, long> getProductByIdAsyncDelegate,
            IConvertDelegate<string, string> convertImagesUriTemplateToUriDelegate,
            IGetValueDelegate<string, Product> getProductImageUriDelegate,
            IStartDelegate startDelegate,
            ISetProgressDelegate setProgressDelegate,
            ICompleteDelegate completeDelegate) :
            base(
                itemizeAllUpdatedAsyncDelegate,
                getProductByIdAsyncDelegate,
                convertImagesUriTemplateToUriDelegate,
                getProductImageUriDelegate,
                startDelegate,
                setProgressDelegate,
                completeDelegate)
        {
            // ...
        }
    }
}