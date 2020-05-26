using Attributes;
using SecretSauce.Delegates.Values.Directories.ProductTypes;
using SecretSauce.Delegates.Values.Filenames.ProductTypes;
using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Values.Paths.ProductTypes
{
    public class GetApiProductsRecordsPathDelegate : GetPathDelegate
    {
        [Dependencies(
            typeof(GetRecordsDirectoryDelegate),
            typeof(GetApiProductsFilenameDelegate))]
        public GetApiProductsRecordsPathDelegate(
            IGetValueDelegate<string, string> getRecordsDirectoryDelegate,
            IGetValueDelegate<string, string> getApiProductsFilenameDelegate) :
            base(
                getRecordsDirectoryDelegate,
                getApiProductsFilenameDelegate)
        {
            // ...
        }
    }
}