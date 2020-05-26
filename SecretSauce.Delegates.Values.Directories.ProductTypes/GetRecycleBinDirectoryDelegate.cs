using Attributes;
using SecretSauce.Delegates.Values.Directories.Root;
using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Values.Directories.ProductTypes
{
    public class GetRecycleBinDirectoryDelegate : GetRelativeDirectoryDelegate
    {
        [Dependencies(
            typeof(GetDataDirectoryDelegate))]
        public GetRecycleBinDirectoryDelegate(
            IGetValueDelegate<string, string> getDataDirectoryDelegate) :
            base(Models.Directories.Directories.RecycleBin, getDataDirectoryDelegate)
        {
            // ...
        }
    }
}