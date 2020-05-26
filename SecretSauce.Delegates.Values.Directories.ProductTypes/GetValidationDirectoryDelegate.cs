using Attributes;
using SecretSauce.Delegates.Values.Directories.Root;
using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Values.Directories.ProductTypes
{
    public class GetMd5DirectoryDelegate : GetRelativeDirectoryDelegate
    {
        [Dependencies(
            typeof(GetDataDirectoryDelegate))]
        public GetMd5DirectoryDelegate(
            IGetValueDelegate<string, string> getDataDirectoryDelegate) :
            base(Models.Directories.Directories.Md5, getDataDirectoryDelegate)
        {
            // ...
        }
    }
}