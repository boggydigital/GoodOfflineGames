using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Attributes;
using Models.QueryParameters;
using Models.Uris;
using SecretSauce.Delegates.Activities;
using SecretSauce.Delegates.Activities.Interfaces;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Conversions.Uris;
using SecretSauce.Delegates.Data.Console;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Network;
using SecretSauce.Delegates.Itemizations.HtmlAttributes;
using SecretSauce.Delegates.Itemizations.Interfaces;

namespace GOG.Delegates.Data.Authorization
{
    public class GetTwoStepLoginCheckDataAsyncDelegate : IGetDataAsyncDelegate<string, string>
    {
        private const string securityCodeHasBeenSent =
            "Enter four digits security code that has been sent to your email:";

        private readonly ICompleteDelegate completeDelegate;

        private readonly IConvertDelegate<IDictionary<string, string>, string>
            convertDictionaryParametersToStringDelegate;

        private readonly IGetDataDelegate<string> getPrivateLineDataDelegate;

        private readonly IPostDataAsyncDelegate<string> postUriDataAsyncDelegate;

        private readonly IStartDelegate startDelegate;

        private IItemizeDelegate<string, string> itemizeSecondStepAuthenticationTokenAttributeValueDelegate;

        [Dependencies(
            typeof(GetPrivateLineDataDelegate),
            typeof(ItemizeSecondStepAuthenticationTokenAttributeValuesDelegate),
            typeof(ConvertDictionaryParametersToStringDelegate),
            typeof(PostUriDataAsyncDelegate),
            typeof(StartDelegate),
            typeof(CompleteDelegate))]
        public GetTwoStepLoginCheckDataAsyncDelegate(
            IGetDataDelegate<string> getPrivateLineDataDelegate,
            IItemizeDelegate<string, string> itemizeSecondStepAuthenticationTokenAttributeValueDelegate,
            IConvertDelegate<IDictionary<string, string>, string> convertDictionaryParametersToStringDelegate,
            IPostDataAsyncDelegate<string> postUriDataAsyncDelegate,
            IStartDelegate startDelegate,
            ICompleteDelegate completeDelegate)
        {
            this.getPrivateLineDataDelegate = getPrivateLineDataDelegate;
            this.itemizeSecondStepAuthenticationTokenAttributeValueDelegate =
                itemizeSecondStepAuthenticationTokenAttributeValueDelegate;
            this.convertDictionaryParametersToStringDelegate = convertDictionaryParametersToStringDelegate;
            this.postUriDataAsyncDelegate = postUriDataAsyncDelegate;
            this.startDelegate = startDelegate;
            this.completeDelegate = completeDelegate;
        }

        public async Task<string> GetDataAsync(string loginCheckResult)
        {
            startDelegate.Start("Get second step authentication result");

            // 2FA is enabled for this user - ask for the code
            var securityCode = getPrivateLineDataDelegate.GetData(securityCodeHasBeenSent);

            var secondStepAuthenticationToken =
                itemizeSecondStepAuthenticationTokenAttributeValueDelegate.Itemize(
                    loginCheckResult).First();

            QueryParametersCollections.SecondStepAuthentication[
                QueryParameters.SecondStepAuthenticationTokenLetter1] = securityCode[0].ToString();
            QueryParametersCollections.SecondStepAuthentication[
                QueryParameters.SecondStepAuthenticationTokenLetter2] = securityCode[1].ToString();
            QueryParametersCollections.SecondStepAuthentication[
                QueryParameters.SecondStepAuthenticationTokenLetter3] = securityCode[2].ToString();
            QueryParametersCollections.SecondStepAuthentication[
                QueryParameters.SecondStepAuthenticationTokenLetter4] = securityCode[3].ToString();
            QueryParametersCollections.SecondStepAuthentication[
                QueryParameters.SecondStepAuthenticationToken] = secondStepAuthenticationToken;

            var secondStepData = convertDictionaryParametersToStringDelegate.Convert(
                QueryParametersCollections.SecondStepAuthentication);

            var secondStepLoginCheckResult = await postUriDataAsyncDelegate.PostDataAsync(
                Uris.Endpoints.Authentication.TwoStep,
                secondStepData);

            completeDelegate.Complete();

            return secondStepLoginCheckResult;
        }
    }
}