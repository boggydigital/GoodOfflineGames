using Attributes;
using SecretSauce.Delegates.Collections.Interfaces;

namespace SecretSauce.Delegates.Collections.ProductTypes
{
    public class FindWishlistedDelegate : FindDelegate<long>
    {
        [Dependencies(
            typeof(FindAllWishlistedDelegate))]
        public FindWishlistedDelegate(
            IFindAllDelegate<long> findAllWishlistedDelegate) :
            base(findAllWishlistedDelegate)
        {
            // ...
        }
    }
}