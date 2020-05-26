using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Collections.Interfaces;

namespace SecretSauce.Delegates.Collections.ProductTypes
{
    public class FindProductRoutesDelegate : FindDelegate<ProductRoutes>
    {
        [Dependencies(
            typeof(FindAllProductRoutesDelegate))]
        public FindProductRoutesDelegate(
            IFindAllDelegate<ProductRoutes> findAllProductRoutesDelegate) :
            base(findAllProductRoutesDelegate)
        {
            // ...
        }
    }
}