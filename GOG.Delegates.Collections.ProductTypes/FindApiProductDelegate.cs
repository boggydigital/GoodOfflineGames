using Attributes;
using GOG.Models;
using SecretSauce.Delegates.Collections;
using SecretSauce.Delegates.Collections.Interfaces;

namespace GOG.Delegates.Collections.ProductTypes
{
    public class FindApiProductDelegate : FindDelegate<ApiProduct>
    {
        [Dependencies(
            typeof(FindAllApiProductDelegate))]
        public FindApiProductDelegate(
            IFindAllDelegate<ApiProduct> findAllApiProductDelegate) :
            base(findAllApiProductDelegate)
        {
            // ...
        }
    }
}