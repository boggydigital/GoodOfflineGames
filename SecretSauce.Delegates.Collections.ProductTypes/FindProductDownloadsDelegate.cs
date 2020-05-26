using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Collections.Interfaces;

namespace SecretSauce.Delegates.Collections.ProductTypes
{
    public class FindProductDownloadsDelegate : FindDelegate<ProductDownloads>
    {
        [Dependencies(
            typeof(FindAllProductDownloadsDelegate))]
        public FindProductDownloadsDelegate(
            IFindAllDelegate<ProductDownloads> findAllProductDownloadsDelegate) :
            base(findAllProductDownloadsDelegate)
        {
            // ...
        }
    }
}