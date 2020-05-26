using Attributes;
using SecretSauce.Delegates.Values.Directories.Root;
using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Values.Directories.ProductTypes
{
    public class GetScreenshotsDirectoryDelegate : GetRelativeDirectoryDelegate
    {
        [Dependencies(
            typeof(GetDataDirectoryDelegate))]
        public GetScreenshotsDirectoryDelegate(
            IGetValueDelegate<string, string> getDataDirectoryDelegate) :
            base(Models.Directories.Directories.Screenshots, getDataDirectoryDelegate)
        {
            // ...
        }
    }
}