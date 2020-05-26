using Attributes;
using SecretSauce.Delegates.Values.Directories.ProductTypes;
using SecretSauce.Delegates.Values.Filenames.ProductTypes;
using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Values.Paths.ProductTypes
{
    public class GetProductScreenshotsRecordsPathDelegate : GetPathDelegate
    {
        [Dependencies(
            typeof(GetRecordsDirectoryDelegate),
            typeof(GetProductScreenshotsFilenameDelegate))]
        public GetProductScreenshotsRecordsPathDelegate(
            IGetValueDelegate<string, string> getRecordsDirectoryDelegate,
            IGetValueDelegate<string, string> getProductScreenshotsFilenameDelegate) :
            base(
                getRecordsDirectoryDelegate,
                getProductScreenshotsFilenameDelegate)
        {
            // ...
        }
    }
}