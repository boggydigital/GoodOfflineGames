using Attributes;
using SecretSauce.Delegates.Values.Directories.ProductTypes;
using SecretSauce.Delegates.Values.Filenames;
using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Values.Paths.JSON
{
    public class GetGameDetailsFilesPathDelegate : GetPathDelegate
    {
        [Dependencies(
            typeof(GetProductFilesDirectoryDelegate),
            typeof(GetUriFilenameDelegate))]
        public GetGameDetailsFilesPathDelegate(
            IGetValueDelegate<string, string> getDirectoryDelegate,
            IGetValueDelegate<string, string> getFilenameDelegate) :
            base(getDirectoryDelegate, getFilenameDelegate)
        {
            // ...
        }
    }
}