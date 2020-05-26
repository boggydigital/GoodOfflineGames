using System;
using Attributes;
using SecretSauce.Delegates.Collections.Interfaces;

namespace SecretSauce.Delegates.Collections.System
{
    public class FindTypeDelegate : FindDelegate<Type>
    {
        [Dependencies(
            typeof(FindAllDelegate<Type>))]
        public FindTypeDelegate(
            IFindAllDelegate<Type> findAllTypeDelegate) :
            base(findAllTypeDelegate)
        {
            // ...
        }
    }
}