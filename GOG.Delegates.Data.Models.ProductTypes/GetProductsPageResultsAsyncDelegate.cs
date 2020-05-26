using System.Collections.Generic;
using Attributes;
using GOG.Delegates.Conversions.JSON;
using GOG.Models;
using SecretSauce.Delegates.Activities;
using SecretSauce.Delegates.Activities.Interfaces;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Conversions.Uris;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Network;
using SecretSauce.Delegates.Values.Interfaces;
using SecretSauce.Delegates.Values.QueryParameters.ProductTypes;
using SecretSauce.Delegates.Values.Uris.ProductTypes;

namespace GOG.Delegates.Data.Models.ProductTypes
{
    public class GetProductsPageResultsAsyncDelegate : GetPageResultsAsyncDelegate<ProductsPageResult>
    {
        [Dependencies(
            typeof(GetProductsUpdateUriDelegate),
            typeof(GetProductsUpdateQueryParametersDelegate),
            typeof(ConvertUriDictionaryParametersToUriDelegate),
            typeof(GetUriDataAsyncDelegate),
            typeof(ConvertJSONToProductsPageResultDelegate),
            typeof(StartDelegate),
            typeof(SetProgressDelegate),
            typeof(CompleteDelegate))]
        public GetProductsPageResultsAsyncDelegate(
            IGetValueDelegate<string, string> getProductsUpdateUriDelegate,
            IGetValueDelegate<Dictionary<string, string>, string> getProductsQueryUpdateQueryParameters,
            IConvertDelegate<(string, IDictionary<string, string>), string>
                convertUriParametersToUriDelegate,
            IGetDataAsyncDelegate<string, string> getUriDataAsyncDelegate,
            IConvertDelegate<string, ProductsPageResult> convertJSONToProductsPageResultDelegate,
            IStartDelegate startDelegate,
            ISetProgressDelegate setProgressDelegate,
            ICompleteDelegate completeDelegate) :
            base(
                getProductsUpdateUriDelegate,
                getProductsQueryUpdateQueryParameters,
                convertUriParametersToUriDelegate,
                getUriDataAsyncDelegate,
                convertJSONToProductsPageResultDelegate,
                startDelegate,
                setProgressDelegate,
                completeDelegate)
        {
            // ...
        }
    }
}