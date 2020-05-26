using Attributes;
using SecretSauce.Delegates.Collections.Interfaces;

namespace SecretSauce.Delegates.Collections.ProductTypes
{
    public class FindUpdatedDelegate : FindDelegate<long>
    {
        [Dependencies(
            typeof(FindAllUpdatedDelegate))]
        public FindUpdatedDelegate(
            IFindAllDelegate<long> findAllUpdatedDelegate) :
            base(findAllUpdatedDelegate)
        {
            // ...
        }
    }
}