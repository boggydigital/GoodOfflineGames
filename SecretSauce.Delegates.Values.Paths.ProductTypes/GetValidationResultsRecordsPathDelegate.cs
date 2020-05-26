using Attributes;
using SecretSauce.Delegates.Values.Directories.ProductTypes;
using SecretSauce.Delegates.Values.Filenames.ProductTypes;
using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Values.Paths.ProductTypes
{
    public class GetValidationResultsRecordsPathDelegate : GetPathDelegate
    {
        [Dependencies(
            typeof(GetRecordsDirectoryDelegate),
            typeof(GetValidationResultsFilenameDelegate))]
        public GetValidationResultsRecordsPathDelegate(
            IGetValueDelegate<string, string> getRecordsDirectoryDelegate,
            IGetValueDelegate<string, string> getValidationResultsFilenameDelegate) :
            base(
                getRecordsDirectoryDelegate,
                getValidationResultsFilenameDelegate)
        {
            // ...
        }
    }
}