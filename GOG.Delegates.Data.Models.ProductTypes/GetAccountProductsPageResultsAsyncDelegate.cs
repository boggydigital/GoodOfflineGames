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
    public class GetAccountProductsPageResultsAsyncDelegate : GetPageResultsAsyncDelegate<AccountProductsPageResult>
    {
        [Dependencies(
            typeof(GetAccountProductsUpdateUriDelegate),
            typeof(GetAccountProductsUpdateQueryParametersDelegate),
            typeof(ConvertUriDictionaryParametersToUriDelegate),
            typeof(GetUriDataAsyncDelegate),
            typeof(ConvertJSONToAccountProductsPageResultDelegate),
            typeof(StartDelegate),
            typeof(SetProgressDelegate),
            typeof(CompleteDelegate))]
        public GetAccountProductsPageResultsAsyncDelegate(
            IGetValueDelegate<string, string> getAccountProductsUpdateUriDelegate,
            IGetValueDelegate<Dictionary<string, string>, string> getAccountProductsQueryUpdateQueryParameters,
            IConvertDelegate<(string, IDictionary<string, string>), string>
                convertUriParametersToUriDelegate,
            IGetDataAsyncDelegate<string, string> getUriDataAsyncDelegate,
            IConvertDelegate<string, AccountProductsPageResult> convertJSONToAccountProductsPageResultDelegate,
            IStartDelegate startDelegate,
            ISetProgressDelegate setProgressDelegate,
            ICompleteDelegate completeDelegate) :
            base(
                getAccountProductsUpdateUriDelegate,
                getAccountProductsQueryUpdateQueryParameters,
                convertUriParametersToUriDelegate,
                getUriDataAsyncDelegate,
                convertJSONToAccountProductsPageResultDelegate,
                startDelegate,
                setProgressDelegate,
                completeDelegate)
        {
            // ...
        }
    }
}