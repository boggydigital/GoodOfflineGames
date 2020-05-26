using System;
using System.Reflection;
using Attributes;
using SecretSauce.Delegates.Conversions.Interfaces;

namespace SecretSauce.Delegates.Conversions.Types
{
    public sealed class ConvertTypeToDependenciesConstructorInfoDelegate : IConvertDelegate<Type, ConstructorInfo>
    {
        public ConstructorInfo Convert(Type type)
        {
            foreach (var constructorInfo in type.GetConstructors())
                if (constructorInfo.IsDefined(typeof(DependenciesAttribute)))
                    return constructorInfo;

            return null;
        }
    }
}