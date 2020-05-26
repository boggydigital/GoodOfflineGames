using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Collections.Interfaces;

namespace SecretSauce.Delegates.Collections.ProductTypes
{
    public class FindProductScreenshotsDelegate : FindDelegate<ProductScreenshots>
    {
        [Dependencies(
            typeof(FindAllProductScreenshotsDelegate))]
        public FindProductScreenshotsDelegate(
            IFindAllDelegate<ProductScreenshots> findAllProductScreenshotsDelegate) :
            base(findAllProductScreenshotsDelegate)
        {
            // ...
        }
    }
}