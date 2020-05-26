using Attributes;
using SecretSauce.Delegates.Values.Directories.Root;
using SecretSauce.Delegates.Values.Filenames.ProductTypes;
using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Values.Paths.ProductTypes
{
    public class GetApiProductsPathDelegate : GetPathDelegate
    {
        [Dependencies(
            typeof(GetDataDirectoryDelegate),
            typeof(GetApiProductsFilenameDelegate))]
        public GetApiProductsPathDelegate(
            IGetValueDelegate<string, string> getDirectoryDelegate,
            IGetValueDelegate<string, string> getApiProductsFilenameDelegate) :
            base(
                getDirectoryDelegate,
                getApiProductsFilenameDelegate)
        {
            // ...
        }
    }
}