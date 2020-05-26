using System.Collections.Generic;
using System.Threading.Tasks;
using Attributes;
using Models.QueryParameters;
using Models.Uris;
using SecretSauce.Delegates.Activities;
using SecretSauce.Delegates.Activities.Interfaces;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Conversions.Uris;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Network;

namespace GOG.Delegates.Data.Authorization
{
    public class GetAuthenticationTokenDataAsyncDelegate : IGetDataAsyncDelegate<string, string>
    {
        private readonly ICompleteDelegate completeDelegate;

        private readonly IConvertDelegate<(string, IDictionary<string, string>), string>
            convertUriParametersToUriDelegate;

        private readonly IGetDataAsyncDelegate<string, string> getUriDataAsyncDelegate;

        private readonly IStartDelegate startDelegate;

        [Dependencies(
            typeof(ConvertUriDictionaryParametersToUriDelegate),
            typeof(GetUriDataAsyncDelegate),
            typeof(StartDelegate),
            typeof(CompleteDelegate))]
        public GetAuthenticationTokenDataAsyncDelegate(
            IConvertDelegate<(string, IDictionary<string, string>), string>
                convertUriParametersToUriDelegate,
            IGetDataAsyncDelegate<string, string> getUriDataAsyncDelegate,
            IStartDelegate startDelegate,
            ICompleteDelegate completeDelegate)
        {
            this.convertUriParametersToUriDelegate = convertUriParametersToUriDelegate;
            this.getUriDataAsyncDelegate = getUriDataAsyncDelegate;
            this.startDelegate = startDelegate;
            this.completeDelegate = completeDelegate;
        }

        public async Task<string> GetDataAsync(string uri)
        {
            startDelegate.Start("Get authorization token response");

            var uriParameters = convertUriParametersToUriDelegate.Convert((
                Uris.Endpoints.Authentication.Auth,
                QueryParametersCollections.Authenticate));
            // request authorization token
            var authResponse = await getUriDataAsyncDelegate.GetDataAsync(uriParameters);

            completeDelegate.Complete();

            return authResponse;
        }
    }
}