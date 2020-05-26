using System;
using System.Collections.Generic;
using SecretSauce.Delegates.Itemizations.Interfaces;

namespace SecretSauce.Delegates.Itemizations.Types
{
    public abstract class ItemizeAllAssemblyTypesDelegate : IItemizeAllDelegate<Type>
    {
        private readonly string assemblyName;

        public ItemizeAllAssemblyTypesDelegate(string assemblyName)
        {
            this.assemblyName = assemblyName;
        }

        public IEnumerable<Type> ItemizeAll()
        {
            return AppDomain.CurrentDomain.Load(assemblyName).GetExportedTypes();
        }
    }
}