using Attributes;
using SecretSauce.Delegates.Values.Directories.Root;
using SecretSauce.Delegates.Values.Filenames.ProductTypes;
using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Values.Paths.ProductTypes
{
    public class GetProductRoutesPathDelegate : GetPathDelegate
    {
        [Dependencies(
            typeof(GetDataDirectoryDelegate),
            typeof(GetProductRoutesFilenameDelegate))]
        public GetProductRoutesPathDelegate(
            IGetValueDelegate<string, string> getDirectoryDelegate,
            IGetValueDelegate<string, string> getProductRoutesFilenameDelegate) :
            base(
                getDirectoryDelegate,
                getProductRoutesFilenameDelegate)
        {
            // ...
        }
    }
}