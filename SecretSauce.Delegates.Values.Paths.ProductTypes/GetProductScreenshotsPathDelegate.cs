using Attributes;
using SecretSauce.Delegates.Values.Directories.Root;
using SecretSauce.Delegates.Values.Filenames.ProductTypes;
using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Values.Paths.ProductTypes
{
    public class GetProductScreenshotsPathDelegate : GetPathDelegate
    {
        [Dependencies(
            typeof(GetDataDirectoryDelegate),
            typeof(GetProductScreenshotsFilenameDelegate))]
        public GetProductScreenshotsPathDelegate(
            IGetValueDelegate<string, string> getDirectoryDelegate,
            IGetValueDelegate<string, string> getProductScreenshotsFilenameDelegate) :
            base(
                getDirectoryDelegate,
                getProductScreenshotsFilenameDelegate)
        {
            // ...
        }
    }
}