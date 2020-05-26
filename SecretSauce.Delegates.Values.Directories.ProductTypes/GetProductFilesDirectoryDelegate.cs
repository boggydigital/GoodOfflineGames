using Attributes;
using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Values.Directories.ProductTypes
{
    public class GetProductFilesDirectoryDelegate : GetUriDirectoryDelegate
    {
        [Dependencies(
            typeof(GetProductFilesRootDirectoryDelegate))]
        public GetProductFilesDirectoryDelegate(
            IGetValueDelegate<string, string> getProductFilesRootDirectoryDelegate) :
            base(getProductFilesRootDirectoryDelegate)
        {
            // ...
        }
    }
}