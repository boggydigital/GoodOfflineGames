using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces.Delegates.Itemizations;

namespace Delegates.Itemizations.Types
{
    public abstract class ItemizeAllTypesWithClassAttributeDelegate<AttributeType> : IItemizeAllDelegate<Type>
    {
        private readonly IItemizeAllDelegate<Type> itemizeAllTypesDelegate;

        public ItemizeAllTypesWithClassAttributeDelegate(
            IItemizeAllDelegate<Type> itemizeAllTypesDelegate)
        {
            this.itemizeAllTypesDelegate = itemizeAllTypesDelegate;
        }

        public IEnumerable<Type> ItemizeAll()
        {
            return itemizeAllTypesDelegate.ItemizeAll().Where(
                type =>
                    type.IsDefined(typeof(AttributeType), false));
        }
    }
}