using Attributes;
using SecretSauce.Delegates.Values.Directories.Root;
using SecretSauce.Delegates.Values.Filenames.JSON;
using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Values.Paths.JSON
{
    public class GetCookiesPathDelegate : GetPathDelegate
    {
        [Dependencies(
            typeof(GetEmptyDirectoryDelegate),
            typeof(GetCookiesFilenameDelegate))]
        public GetCookiesPathDelegate(
            IGetValueDelegate<string, string> getDirectoryDelegate,
            IGetValueDelegate<string, string> getFilenameDelegate) :
            base(getDirectoryDelegate, getFilenameDelegate)
        {
            // ...
        }
    }
}