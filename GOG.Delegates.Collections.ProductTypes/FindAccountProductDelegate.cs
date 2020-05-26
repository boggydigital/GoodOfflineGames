using Attributes;
using GOG.Models;
using SecretSauce.Delegates.Collections;
using SecretSauce.Delegates.Collections.Interfaces;

namespace GOG.Delegates.Collections.ProductTypes
{
    public class FindAccountProductDelegate : FindDelegate<AccountProduct>
    {
        [Dependencies(
            typeof(FindAllAccountProductDelegate))]
        public FindAccountProductDelegate(
            IFindAllDelegate<AccountProduct> findAllAccountProductDelegate) :
            base(findAllAccountProductDelegate)
        {
            // ...
        }
    }
}