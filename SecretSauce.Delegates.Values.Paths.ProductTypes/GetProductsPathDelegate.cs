using Attributes;
using SecretSauce.Delegates.Values.Directories.Root;
using SecretSauce.Delegates.Values.Filenames.ProductTypes;
using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Values.Paths.ProductTypes
{
    public class GetProductsPathDelegate : GetPathDelegate
    {
        [Dependencies(
            typeof(GetDataDirectoryDelegate),
            typeof(GetProductsFilenameDelegate))]
        public GetProductsPathDelegate(
            IGetValueDelegate<string, string> getDirectoryDelegate,
            IGetValueDelegate<string, string> getProductsFilenameDelegate) :
            base(
                getDirectoryDelegate,
                getProductsFilenameDelegate)
        {
            // ...
        }
    }
}