using System;
using Attributes;
using SecretSauce.Delegates.Itemizations.Interfaces;
using SecretSauce.Delegates.Itemizations.Types;

namespace GOG.Delegates.Itemizations.Types.Attributes
{
    public class ItemizeAllApiEndpointAttributeTypesDelegate :
        ItemizeAllTypesWithClassAttributeDelegate<ApiEndpointAttribute>
    {
        [Dependencies(
            typeof(ItemizeAllGOGDelegatesServerTypes))]
        public ItemizeAllApiEndpointAttributeTypesDelegate(
            IItemizeAllDelegate<Type> itemizeAllAssemblyTypesDelegate) :
            base(itemizeAllAssemblyTypesDelegate)
        {
            // ...
        }
    }
}