using Attributes;
using SecretSauce.Delegates.Collections.Interfaces;

namespace SecretSauce.Delegates.Collections.System
{
    public class IntersectStringDelegate : IntersectDelegate<string>
    {
        [Dependencies(
            typeof(FindAllDelegate<string>),
            typeof(FindStringDelegate))]
        public IntersectStringDelegate(
            IFindAllDelegate<string> findAllStringDelegate,
            IFindDelegate<string> findStringDelegate) :
            base(findAllStringDelegate, findStringDelegate)
        {
            // ...
        }
    }
}