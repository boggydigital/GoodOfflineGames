using System.Text.RegularExpressions;
using Attributes;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Conversions.Strings;

namespace GOG.Delegates.Conversions.ProductTypes
{
    public class ConvertGameDetailsDownloadLanguagesToEmptyStringDelegate : IConvertDelegate<string, string>
    {
        private readonly IConvertDelegate<(string, string[]), string>
            convertStringToReplaceMarkersWithEmptyStringDelegate;

        [Dependencies(
            typeof(ConvertStringToReplaceMarkersWithEmptyStringDelegate))]
        public ConvertGameDetailsDownloadLanguagesToEmptyStringDelegate(
            IConvertDelegate<(string, string[]), string>
                convertStringToReplaceMarkersWithEmptyStringDelegate)
        {
            this.convertStringToReplaceMarkersWithEmptyStringDelegate =
                convertStringToReplaceMarkersWithEmptyStringDelegate;
        }

        public string Convert(string downloadLanguage)
        {
            downloadLanguage = convertStringToReplaceMarkersWithEmptyStringDelegate.Convert(
                (downloadLanguage,
                    new[] {"\"", ","}));

            downloadLanguage = Regex.Unescape(downloadLanguage);

            return downloadLanguage;
        }
    }
}