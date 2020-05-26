using Attributes;
using GOG.Models;
using SecretSauce.Delegates.Collections;
using SecretSauce.Delegates.Collections.Interfaces;

namespace GOG.Delegates.Collections.ProductTypes
{
    public class FindProductDelegate : FindDelegate<Product>
    {
        [Dependencies(
            typeof(FindAllProductDelegate))]
        public FindProductDelegate(
            IFindAllDelegate<Product> findAllProductDelegate) :
            base(findAllProductDelegate)
        {
            // ...
        }
    }
}