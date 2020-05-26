using Attributes;
using SecretSauce.Delegates.Values.Directories.Root;
using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Values.Directories.ProductTypes
{
    public class GetProductFilesRootDirectoryDelegate : GetRelativeDirectoryDelegate
    {
        [Dependencies(
            typeof(GetDataDirectoryDelegate))]
        public GetProductFilesRootDirectoryDelegate(
            IGetValueDelegate<string, string> getDataDirectoryDelegate) :
            base(Models.Directories.Directories.ProductFiles, getDataDirectoryDelegate)
        {
            // ...
        }
    }
}