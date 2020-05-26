using Attributes;
using SecretSauce.Delegates.Values.Directories.Root;
using SecretSauce.Delegates.Values.Filenames.ProductTypes;
using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Values.Paths.ProductTypes
{
    public class GetProductDownloadsPathDelegate : GetPathDelegate
    {
        [Dependencies(
            typeof(GetDataDirectoryDelegate),
            typeof(GetProductDownloadsFilenameDelegate))]
        public GetProductDownloadsPathDelegate(
            IGetValueDelegate<string, string> getDirectoryDelegate,
            IGetValueDelegate<string, string> getProductDownloadsFilenameDelegate) :
            base(
                getDirectoryDelegate,
                getProductDownloadsFilenameDelegate)
        {
            // ...
        }
    }
}