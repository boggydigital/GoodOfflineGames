using Attributes;
using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Values.Filenames.ProductTypes
{
    public class GetAccountProductsFilenameDelegate : GetFixedFilenameDelegate
    {
        [Dependencies(
            typeof(GetBinFilenameDelegate))]
        public GetAccountProductsFilenameDelegate(IGetValueDelegate<string, string> GetBinFilenameDelegate) :
            base(Models.Filenames.Filenames.AccountProducts, GetBinFilenameDelegate)
        {
            // ...
        }
    }
}