using System;
using System.Collections.Generic;
using System.Linq;
using SecretSauce.Delegates.Itemizations.Interfaces;

namespace SecretSauce.Delegates.Itemizations.Types
{
    public class ItemizeAllAppDomainTypesDelegate : IItemizeAllDelegate<Type>
    {
        public IEnumerable<Type> ItemizeAll()
        {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes());
        }
    }
}