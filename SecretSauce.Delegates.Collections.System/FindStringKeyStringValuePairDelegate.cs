using System.Collections.Generic;
using Attributes;
using SecretSauce.Delegates.Collections.Interfaces;

namespace SecretSauce.Delegates.Collections.System
{
    public class FindStringKeyStringValuePairDelegate : FindDelegate<KeyValuePair<string, string>>
    {
        [Dependencies(
            typeof(FindAllDelegate<KeyValuePair<string, string>>))]
        public FindStringKeyStringValuePairDelegate(
            IFindAllDelegate<KeyValuePair<string, string>> findAllStringKeyStringValuePairDelegate) :
            base(findAllStringKeyStringValuePairDelegate)
        {
            // ...
        }
    }
}