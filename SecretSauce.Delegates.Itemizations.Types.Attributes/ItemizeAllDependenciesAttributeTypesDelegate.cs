using System;
using Attributes;
using SecretSauce.Delegates.Itemizations.Interfaces;

namespace SecretSauce.Delegates.Itemizations.Types.Attributes
{
    public class ItemizeAllDependenciesAttributeTypesDelegate :
        ItemizeAllTypesWithConstructorAttributeDelegate<DependenciesAttribute>
    {
        [Dependencies(
            typeof(ItemizeAllAppDomainTypesDelegate))]
        public ItemizeAllDependenciesAttributeTypesDelegate(
            IItemizeAllDelegate<Type> itemizeAllAppDomainTypesDelegate) :
            base(itemizeAllAppDomainTypesDelegate)
        {
            // ...
        }
    }
}