using System.IO;
using System.Threading.Tasks;
using Attributes;
using GOG.Models;
using SecretSauce.Delegates.Activities;
using SecretSauce.Delegates.Activities.Interfaces;
using SecretSauce.Delegates.Confirmations.Interfaces;
using SecretSauce.Delegates.Confirmations.Validation;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Conversions.Uris;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Network;
using SecretSauce.Delegates.Values.Directories.ProductTypes;
using SecretSauce.Delegates.Values.Interfaces;

namespace GOG.Delegates.Data.Models
{
    public class GetValidationFileAsyncDelegate : IGetDataAsyncDelegate<string, ProductFileDownloadManifest>
    {
        private readonly ICompleteDelegate completeDelegate;
        private readonly IConfirmDelegate<string> confirmValidationExpectedDelegate;
        private readonly IConvertDelegate<string, string> convertFilePathToValidationFilePathDelegate;
        private readonly IConvertDelegate<string, string> convertSessionUriToUriSansSessionDelegate;
        private readonly IConvertDelegate<string, string> convertUriToValidationFileUriDelegate;
        private readonly IGetDataToDestinationAsyncDelegate<string, string> getUriDataToDestinationAsyncDelegate;
        private readonly IStartDelegate startDelegate;
        private readonly IGetValueDelegate<string, string> validationDirectoryDelegate;

        [Dependencies(
            typeof(ConvertSessionUriToUriSansSessionDelegate),
            typeof(ConfirmFileValidationSupportedDelegate),
            typeof(ConvertFilePathToValidationFilePathDelegate),
            typeof(GetMd5DirectoryDelegate),
            typeof(ConvertUriToValidationFileUriDelegate),
            typeof(GetUriDataToDestinationAsyncDelegate),
            typeof(StartDelegate),
            typeof(CompleteDelegate))]
        public GetValidationFileAsyncDelegate(
            IConvertDelegate<string, string> convertSessionUriToUriSansSessionDelegate,
            IConfirmDelegate<string> confirmValidationExpectedDelegate,
            IConvertDelegate<string, string> convertFilePathToValidationFilePathDelegate,
            IGetValueDelegate<string, string> validationDirectoryDelegate,
            IConvertDelegate<string, string> convertUriToValidationFileUriDelegate,
            IGetDataToDestinationAsyncDelegate<string, string> getUriDataToDestinationAsyncDelegate,
            IStartDelegate startDelegate,
            ICompleteDelegate completeDelegate)
        {
            this.convertSessionUriToUriSansSessionDelegate = convertSessionUriToUriSansSessionDelegate;
            this.confirmValidationExpectedDelegate = confirmValidationExpectedDelegate;
            this.convertFilePathToValidationFilePathDelegate = convertFilePathToValidationFilePathDelegate;
            this.validationDirectoryDelegate = validationDirectoryDelegate;
            this.convertUriToValidationFileUriDelegate = convertUriToValidationFileUriDelegate;
            this.getUriDataToDestinationAsyncDelegate = getUriDataToDestinationAsyncDelegate;
            this.startDelegate = startDelegate;
            this.completeDelegate = completeDelegate;
        }

        public async Task<string> GetDataAsync(ProductFileDownloadManifest downloadManifest)
        {
            if (string.IsNullOrEmpty(downloadManifest.Source)) return string.Empty;

            var sourceUriSansSession = convertSessionUriToUriSansSessionDelegate.Convert(downloadManifest.Source);
            var destinationUri = convertFilePathToValidationFilePathDelegate.Convert(sourceUriSansSession);

            // return early if validation is not expected for this file
            if (!confirmValidationExpectedDelegate.Confirm(sourceUriSansSession)) return string.Empty;

            if (File.Exists(destinationUri))
                // await statusController.InformAsync(status, "Validation file already exists, will not be redownloading");
                return string.Empty;

            var validationSourceUri = convertUriToValidationFileUriDelegate.Convert(downloadManifest.Source);

            startDelegate.Start("Download validation file");

            await getUriDataToDestinationAsyncDelegate.GetDataToDestinationAsyncDelegate(
                validationSourceUri,
                validationDirectoryDelegate.GetValue(string.Empty));

            completeDelegate.Complete();

            return downloadManifest.Destination;
        }
    }
}