using Attributes;
using SecretSauce.Delegates.Values.Directories.Root;
using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Values.Directories.ProductTypes
{
    public class GetProductImagesDirectoryDelegate : GetRelativeDirectoryDelegate
    {
        [Dependencies(
            typeof(GetDataDirectoryDelegate))]
        public GetProductImagesDirectoryDelegate(
            IGetValueDelegate<string, string> getDataDirectoryDelegate) :
            base(Models.Directories.Directories.ProductImages, getDataDirectoryDelegate)
        {
            // ...
        }
    }
}