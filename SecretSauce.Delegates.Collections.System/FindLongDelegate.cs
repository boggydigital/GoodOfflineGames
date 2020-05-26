using Attributes;
using SecretSauce.Delegates.Collections.Interfaces;

namespace SecretSauce.Delegates.Collections.System
{
    public class FindLongDelegate : FindDelegate<long>
    {
        [Dependencies(
            typeof(FindAllDelegate<long>))]
        public FindLongDelegate(
            IFindAllDelegate<long> findAllLongDelegate) :
            base(findAllLongDelegate)
        {
            // ...
        }
    }
}