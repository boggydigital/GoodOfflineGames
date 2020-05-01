﻿using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Interfaces.Delegates.Activities;
using Interfaces.Delegates.Itemize;
using Interfaces.Delegates.Convert;
using Interfaces.Delegates.Data;
using Attributes;
using Models.Uris;
using Models.QueryParameters;

namespace GOG.Delegates.Authorization
{
    public class GetTwoStepLoginCheckDataAsyncDelegate: IGetDataAsyncDelegate<string, string>
    {
        private const string securityCodeHasBeenSent =
            "Enter four digits security code that has been sent to your email:";
        
        private readonly IGetDataDelegate<string> getPrivateLineDataDelegate;

        private readonly IConvertDelegate<IDictionary<string, string>, string>
            convertDictionaryParametersToStringDelegate;

        private readonly IConvertDelegate<(string, IDictionary<string, string>), string>
            convertUriParametersToUriDelegate;

        private readonly IPostDataAsyncDelegate<string> postUriDataAsyncDelegate;

        private IItemizeDelegate<string, string> itemizeSecondStepAuthenticationTokenAttributeValueDelegate;

        private readonly IStartDelegate startDelegate;
        private readonly ICompleteDelegate completeDelegate;

        [Dependencies(
            "Delegates.Data.Console.GetPrivateLineDataDelegate,Delegates",
            "Delegates.Itemize.HtmlAttributes.ItemizeSecondStepAuthenticationTokenAttributeValuesDelegate,Delegates",
            "Delegates.Convert.Uri.ConvertDictionaryParametersToStringDelegate,Delegates",
            "Delegates.Data.Network.PostUriDataAsyncDelegate,Delegates",
            "Delegates.Activities.StartDelegate,Delegates",
            "Delegates.Activities.CompleteDelegate,Delegates")]
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