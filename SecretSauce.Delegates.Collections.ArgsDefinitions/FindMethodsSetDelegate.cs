using Attributes;
using Models.ArgsDefinitions;
using SecretSauce.Delegates.Collections.Interfaces;

namespace SecretSauce.Delegates.Collections.ArgsDefinitions
{
    public class FindMethodsSetDelegate : FindDelegate<MethodsSet>
    {
        [Dependencies(
            typeof(FindAllMethodsSetDelegate))]
        public FindMethodsSetDelegate(
            IFindAllDelegate<MethodsSet> findAllMethodsSetDelegate) :
            base(findAllMethodsSetDelegate)
        {
            // ...
        }
    }
}