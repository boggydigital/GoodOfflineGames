using Attributes;
using Models.ArgsDefinitions;
using SecretSauce.Delegates.Collections.Interfaces;

namespace SecretSauce.Delegates.Collections.ArgsDefinitions
{
    public class FindParameterDelegate : FindDelegate<Parameter>
    {
        [Dependencies(
            typeof(FindAllParameterDelegate))]
        public FindParameterDelegate(
            IFindAllDelegate<Parameter> findAllParameterDelegate) :
            base(findAllParameterDelegate)
        {
            // ...
        }
    }
}