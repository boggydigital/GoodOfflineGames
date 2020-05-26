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
    public class ItemizeAllAccountProductImagesDownloadSourcesAsyncDelegate :
        ItemizeAllProductCoreImagesDownloadSourcesAsyncDelegate<AccountProduct>
    {
        [Dependencies(
            typeof(ItemizeAllUpdatedAsyncDelegate),
            typeof(GetAccountProductByIdAsyncDelegate),
            typeof(ConvertImagesUriTemplateToUriDelegate),
            typeof(GetAccountProductImageUriDelegate),
            typeof(StartDelegate),
            typeof(SetProgressDelegate),
            typeof(CompleteDelegate))]
        public ItemizeAllAccountProductImagesDownloadSourcesAsyncDelegate(
            IItemizeAllAsyncDelegate<long> itemizeAllUpdatedAsyncDelegate,
            IGetDataAsyncDelegate<AccountProduct, long> getAccountProductByIdAsyncDelegate,
            IConvertDelegate<string, string> convertImagesUriTemplateToUriDelegate,
            IGetValueDelegate<string, AccountProduct> getAccountProductImageUriDelegate,
            IStartDelegate startDelegate,
            ISetProgressDelegate setProgressDelegate,
            ICompleteDelegate completeDelegate) :
            base(
                itemizeAllUpdatedAsyncDelegate,
                getAccountProductByIdAsyncDelegate,
                convertImagesUriTemplateToUriDelegate,
                getAccountProductImageUriDelegate,
                startDelegate,
                setProgressDelegate,
                completeDelegate)
        {
            // ...
        }
    }
}