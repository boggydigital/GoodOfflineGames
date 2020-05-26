using Attributes;
using SecretSauce.Delegates.Collections.Interfaces;

namespace SecretSauce.Delegates.Collections.System
{
    public class FindStringDelegate : FindDelegate<string>
    {
        [Dependencies(
            typeof(FindAllDelegate<string>))]
        public FindStringDelegate(
            IFindAllDelegate<string> findAllStringDelegate) :
            base(findAllStringDelegate)
        {
            // ...
        }
    }
}