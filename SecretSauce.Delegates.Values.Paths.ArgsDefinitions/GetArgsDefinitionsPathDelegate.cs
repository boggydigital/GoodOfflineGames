using Attributes;
using SecretSauce.Delegates.Values.Directories.Root;
using SecretSauce.Delegates.Values.Filenames.ArgsDefinitions;
using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Values.Paths.ArgsDefinitions
{
    public class GetArgsDefinitionsPathDelegate : GetPathDelegate
    {
        [Dependencies(
            typeof(GetEmptyDirectoryDelegate),
            typeof(GetArgsDefinitionsFilenameDelegate))]
        public GetArgsDefinitionsPathDelegate(
            IGetValueDelegate<string, string> getDirectoryDelegate,
            IGetValueDelegate<string, string> getFilenameDelegate) :
            base(getDirectoryDelegate, getFilenameDelegate)
        {
            // ...
        }
    }
}