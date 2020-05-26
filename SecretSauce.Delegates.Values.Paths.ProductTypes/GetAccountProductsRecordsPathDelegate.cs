using Attributes;
using SecretSauce.Delegates.Values.Directories.ProductTypes;
using SecretSauce.Delegates.Values.Filenames.ProductTypes;
using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Values.Paths.ProductTypes
{
    public class GetAccountProductsRecordsPathDelegate : GetPathDelegate
    {
        [Dependencies(
            typeof(GetRecordsDirectoryDelegate),
            typeof(GetAccountProductsFilenameDelegate))]
        public GetAccountProductsRecordsPathDelegate(
            IGetValueDelegate<string, string> getRecordsDirectoryDelegate,
            IGetValueDelegate<string, string> getAccountProductsFilenameDelegate) :
            base(
                getRecordsDirectoryDelegate,
                getAccountProductsFilenameDelegate)
        {
            // ...
        }
    }
}