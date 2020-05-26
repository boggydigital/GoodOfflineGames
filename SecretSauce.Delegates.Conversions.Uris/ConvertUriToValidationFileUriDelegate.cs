using System.IO;
using Attributes;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Values.Filenames;
using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Conversions.Uris
{
    public class ConvertUriToValidationFileUriDelegate : IConvertDelegate<string, string>
    {
        private readonly IConvertDelegate<string, string> convertSessionUriToUriSansSessionDelegate;
        private readonly IGetValueDelegate<string, string> getValidationFilenameDelegate;

        [Dependencies(
            typeof(GetValidationFilenameDelegate),
            typeof(ConvertSessionUriToUriSansSessionDelegate))]
        public ConvertUriToValidationFileUriDelegate(
            IGetValueDelegate<string, string> getValidationFilenameDelegate,
            IConvertDelegate<string, string> convertSessionUriToUriSansSessionDelegate)
        {
            this.getValidationFilenameDelegate = getValidationFilenameDelegate;
            this.convertSessionUriToUriSansSessionDelegate = convertSessionUriToUriSansSessionDelegate;
        }

        public string Convert(string sourceUri)
        {
            var sourceUriSansSession = convertSessionUriToUriSansSessionDelegate.Convert(sourceUri);
            var sourceFilename = Path.GetFileName(sourceUriSansSession);
            var validationFilename = getValidationFilenameDelegate.GetValue(sourceFilename);

            return sourceUri.Replace(sourceFilename, validationFilename);
        }
    }
}