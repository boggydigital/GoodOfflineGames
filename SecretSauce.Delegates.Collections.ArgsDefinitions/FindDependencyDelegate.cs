using Attributes;
using Models.ArgsDefinitions;
using SecretSauce.Delegates.Collections.Interfaces;

namespace SecretSauce.Delegates.Collections.ArgsDefinitions
{
    public class FindDependencyDelegate : FindDelegate<Dependency>
    {
        [Dependencies(
            typeof(FindAllDependencyDelegate))]
        public FindDependencyDelegate(
            IFindAllDelegate<Dependency> findAllDependencyDelegate) :
            base(findAllDependencyDelegate)
        {
            // ...
        }
    }
}