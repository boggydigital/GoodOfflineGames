using System.Threading.Tasks;
using Attributes;
using GOG.Delegates.Conversions.JSON;
using GOG.Models;
using Models.Uris;
using SecretSauce.Delegates.Activities;
using SecretSauce.Delegates.Activities.Interfaces;
using SecretSauce.Delegates.Confirmations.Interfaces;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Network;

namespace GOG.Delegates.Confirmations.Authorization
{
    public class ConfirmUserIsLoggedInAsyncDelegate : IConfirmAsyncDelegate<string>
    {
        private readonly ICompleteDelegate completeDelegate;
        private readonly IConvertDelegate<string, UserData> convertJSONToUserDataDelegate;
        private readonly IGetDataAsyncDelegate<string, string> getUriDataAsyncDelegate;

        private readonly IStartDelegate startDelegate;

        [Dependencies(
            typeof(GetUriDataAsyncDelegate),
            typeof(ConvertJSONToUserDataDelegate),
            typeof(StartDelegate),
            typeof(CompleteDelegate))]
        public ConfirmUserIsLoggedInAsyncDelegate(
            IGetDataAsyncDelegate<string, string> getUriDataAsyncDelegate,
            IConvertDelegate<string, UserData> convertJSONToUserDataDelegate,
            IStartDelegate startDelegate,
            ICompleteDelegate completeDelegate)
        {
            this.getUriDataAsyncDelegate = getUriDataAsyncDelegate;
            this.convertJSONToUserDataDelegate = convertJSONToUserDataDelegate;
            this.startDelegate = startDelegate;
            this.completeDelegate = completeDelegate;
        }

        public async Task<bool> ConfirmAsync(string data)
        {
            startDelegate.Start("Get userData.json");

            var userDataString = await getUriDataAsyncDelegate.GetDataAsync(
                Uris.Endpoints.Authentication.UserData);

            if (string.IsNullOrEmpty(userDataString)) return false;

            var userData = convertJSONToUserDataDelegate.Convert(userDataString);

            completeDelegate.Complete();

            return userData.IsLoggedIn;
        }
    }
}