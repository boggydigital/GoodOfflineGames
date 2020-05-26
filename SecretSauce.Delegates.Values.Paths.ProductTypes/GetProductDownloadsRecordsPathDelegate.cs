using Attributes;
using SecretSauce.Delegates.Values.Directories.ProductTypes;
using SecretSauce.Delegates.Values.Filenames.ProductTypes;
using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Values.Paths.ProductTypes
{
    public class GetProductDownloadsRecordsPathDelegate : GetPathDelegate
    {
        [Dependencies(
            typeof(GetRecordsDirectoryDelegate),
            typeof(GetProductDownloadsFilenameDelegate))]
        public GetProductDownloadsRecordsPathDelegate(
            IGetValueDelegate<string, string> getRecordsDirectoryDelegate,
            IGetValueDelegate<string, string> getProductDownloadsFilenameDelegate) :
            base(
                getRecordsDirectoryDelegate,
                getProductDownloadsFilenameDelegate)
        {
            // ...
        }
    }
}