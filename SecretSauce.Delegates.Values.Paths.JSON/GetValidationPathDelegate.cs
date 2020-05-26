using Attributes;
using SecretSauce.Delegates.Values.Directories.ProductTypes;
using SecretSauce.Delegates.Values.Filenames;
using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Values.Paths.JSON
{
    public class GetValidationPathDelegate : GetPathDelegate
    {
        [Dependencies(
            typeof(GetMd5DirectoryDelegate),
            typeof(GetValidationFilenameDelegate))]
        public GetValidationPathDelegate(
            IGetValueDelegate<string, string> getDirectoryDelegate,
            IGetValueDelegate<string, string> getFilenameDelegate) :
            base(getDirectoryDelegate, getFilenameDelegate)
        {
            // ...
        }
    }
}