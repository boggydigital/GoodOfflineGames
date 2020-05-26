using Attributes;
using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Values.Filenames.JSON
{
    public class GetIndexFilenameDelegate : GetFixedFilenameDelegate
    {
        [Dependencies(
            typeof(GetBinFilenameDelegate))]
        public GetIndexFilenameDelegate(IGetValueDelegate<string, string> getBinFilenameDelegate) :
            base(Models.Filenames.Filenames.Index, getBinFilenameDelegate)
        {
            // ...
        }
    }
}