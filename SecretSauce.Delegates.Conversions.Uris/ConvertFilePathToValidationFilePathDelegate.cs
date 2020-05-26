using System.IO;
using Attributes;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Values.Interfaces;
using SecretSauce.Delegates.Values.Paths.JSON;

namespace SecretSauce.Delegates.Conversions.Uris
{
    public class ConvertFilePathToValidationFilePathDelegate : IConvertDelegate<string, string>
    {
        private readonly IGetValueDelegate<string, (string Directory, string Filename)> getValidationPathDelegate;

        [Dependencies(
            typeof(GetValidationPathDelegate))]
        public ConvertFilePathToValidationFilePathDelegate(
            IGetValueDelegate<string, (string Directory, string Filename)> getValidationPathDelegate)
        {
            this.getValidationPathDelegate = getValidationPathDelegate;
        }

        public string Convert(string filePath)
        {
            return getValidationPathDelegate.GetValue((
                string.Empty,
                Path.GetFileName(filePath)));
        }
    }
}