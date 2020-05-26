using Attributes;
using SecretSauce.Delegates.Values.Directories.Root;
using SecretSauce.Delegates.Values.Filenames.ProductTypes;
using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Values.Paths.ProductTypes
{
    public class GetGameDetailsPathDelegate : GetPathDelegate
    {
        [Dependencies(
            typeof(GetDataDirectoryDelegate),
            typeof(GetGameDetailsFilenameDelegate))]
        public GetGameDetailsPathDelegate(
            IGetValueDelegate<string, string> getDirectoryDelegate,
            IGetValueDelegate<string, string> getGameDetailsFilenameDelegate) :
            base(
                getDirectoryDelegate,
                getGameDetailsFilenameDelegate)
        {
            // ...
        }
    }
}