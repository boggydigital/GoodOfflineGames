using Attributes;
using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Values.Filenames.ProductTypes
{
    public class GetProductDownloadsFilenameDelegate : GetFixedFilenameDelegate
    {
        [Dependencies(
            typeof(GetBinFilenameDelegate))]
        public GetProductDownloadsFilenameDelegate(IGetValueDelegate<string, string> GetBinFilenameDelegate) :
            base(Models.Filenames.Filenames.ProductDownloads, GetBinFilenameDelegate)
        {
            // ...
        }
    }
}