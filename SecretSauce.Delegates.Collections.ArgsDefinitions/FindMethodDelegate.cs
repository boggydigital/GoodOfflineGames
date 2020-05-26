using Attributes;
using Models.ArgsDefinitions;
using SecretSauce.Delegates.Collections.Interfaces;

namespace SecretSauce.Delegates.Collections.ArgsDefinitions
{
    public class FindMethodDelegate : FindDelegate<Method>
    {
        [Dependencies(
            typeof(FindAllMethodDelegate))]
        public FindMethodDelegate(
            IFindAllDelegate<Method> findAllMethodDelegate) :
            base(findAllMethodDelegate)
        {
            // ...
        }
    }
}