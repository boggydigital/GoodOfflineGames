using Attributes;
using SecretSauce.Delegates.Collections.Interfaces;
using SecretSauce.Delegates.Collections.System;

namespace SecretSauce.Delegates.Confirmations.System
{
    public class ConfirmExclusiveStringDelegate : ConfirmExclusiveDelegate<string>
    {
        [Dependencies(
            typeof(IntersectStringDelegate))]
        public ConfirmExclusiveStringDelegate(
            IIntersectDelegate<string> intersectStringDelegate) :
            base(intersectStringDelegate)
        {
            // ...
        }
    }
}