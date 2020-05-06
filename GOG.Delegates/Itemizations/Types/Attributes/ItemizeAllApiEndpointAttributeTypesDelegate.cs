using System;
using Attributes;
using Delegates.Itemizations.Types;
using Interfaces.Delegates.Itemizations;

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