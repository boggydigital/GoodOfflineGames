using Attributes;
using GOG.Delegates.Conversions.UpdateIdentity;
using GOG.Delegates.Conversions.UpdateIdentity.ProductTypes;
using GOG.Delegates.Data.Models.ProductTypes;
using GOG.Delegates.Itemizations.MasterDetail;
using GOG.Models;
using SecretSauce.Delegates.Activities;
using SecretSauce.Delegates.Activities.Interfaces;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Itemizations.Interfaces;
using SecretSauce.Delegates.Values.Interfaces;
using SecretSauce.Delegates.Values.Uris.ProductTypes;

namespace GOG.Delegates.Server.Update
{
    [ApiEndpoint(Method = "update", Collection = "apiproducts")]
    public class UpdateApiProductsAsyncDelegate :
        UpdateMasterDetailsAsyncDelegate<ApiProduct, Product>
    {
        [Dependencies(
            typeof(GetApiProductsUpdateUriDelegate),
            typeof(ConvertProductToApiProductUpdateIdentityDelegate),
            typeof(UpdateApiProductsAsyncDelegate),
            typeof(CommitApiProductsAsyncDelegate),
            typeof(ItemizeAllProductsApiProductsGapsAsyncDelegate),
            typeof(GetDeserializedApiProductAsyncDelegate),
            typeof(StartDelegate),
            typeof(SetProgressDelegate),
            typeof(CompleteDelegate))]
        public UpdateApiProductsAsyncDelegate(
            IGetValueDelegate<string, string> getApiProductsUpdateUriDelegate,
            IConvertDelegate<Product, string> convertProductToApiProductUpdateIdentityDelegate,
            IUpdateAsyncDelegate<ApiProduct> updateApiProductsAsyncDelegate,
            ICommitAsyncDelegate commitApiProductsAsyncDelegate,
            IItemizeAllAsyncDelegate<Product> itemizeAllProductsApiProductsGapsAsyncDelegate,
            IGetDataAsyncDelegate<ApiProduct, string> getDeserializedApiProductAsyncDelegate,
            IStartDelegate startDelegate,
            ISetProgressDelegate setProgressDelegate,
            ICompleteDelegate completeDelegate) :
            base(
                getApiProductsUpdateUriDelegate,
                convertProductToApiProductUpdateIdentityDelegate,
                updateApiProductsAsyncDelegate,
                commitApiProductsAsyncDelegate,
                itemizeAllProductsApiProductsGapsAsyncDelegate,
                getDeserializedApiProductAsyncDelegate,
                startDelegate,
                setProgressDelegate,
                completeDelegate)
        {
            // ...
        }
    }
}