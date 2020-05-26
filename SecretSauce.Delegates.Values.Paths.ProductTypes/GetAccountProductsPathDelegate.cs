using Attributes;
using SecretSauce.Delegates.Values.Directories.Root;
using SecretSauce.Delegates.Values.Filenames.ProductTypes;
using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Values.Paths.ProductTypes
{
    public class GetAccountProductsPathDelegate : GetPathDelegate
    {
        [Dependencies(
            typeof(GetDataDirectoryDelegate),
            typeof(GetAccountProductsFilenameDelegate))]
        public GetAccountProductsPathDelegate(
            IGetValueDelegate<string, string> getDirectoryDelegate,
            IGetValueDelegate<string, string> getAccountProductsFilenameDelegate) :
            base(
                getDirectoryDelegate,
                getAccountProductsFilenameDelegate)
        {
            // ...
        }
    }
}