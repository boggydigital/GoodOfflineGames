using Attributes;
using SecretSauce.Delegates.Values.Directories.Root;
using SecretSauce.Delegates.Values.Filenames.ProductTypes;
using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Values.Paths.ProductTypes
{
    public class GetValidationResultsPathDelegate : GetPathDelegate
    {
        [Dependencies(
            typeof(GetDataDirectoryDelegate),
            typeof(GetValidationResultsFilenameDelegate))]
        public GetValidationResultsPathDelegate(
            IGetValueDelegate<string, string> getDirectoryDelegate,
            IGetValueDelegate<string, string> getValidationResultsFilenameDelegate) :
            base(
                getDirectoryDelegate,
                getValidationResultsFilenameDelegate)
        {
            // ...
        }
    }
}