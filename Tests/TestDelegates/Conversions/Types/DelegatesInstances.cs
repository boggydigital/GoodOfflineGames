using System;
using System.Reflection;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Conversions.Types;
using Tests.TestModels.Dependencies;

namespace Tests.TestDelegates.Conversions.Types
{
    public static class DelegatesInstances
    {
        public static IConvertDelegate<Type, ConstructorInfo> TestConvertTypeToDependenciesConstructorInfoDelegate =
            new ConvertTypeToDependenciesConstructorInfoDelegate();

        public static IConvertDelegate<ConstructorInfo, Type[]> TestConvertConstructorInfoToDependenciesTypesDelegate =
            new ConvertConstructorInfoToDependenciesTypesDelegate(
                TestContextReplacements.Map);

        public static IConvertDelegate<Type, object> TestConvertTypeToInstanceDelegate =
            new ConvertTypeToInstanceDelegate(
                TestConvertTypeToDependenciesConstructorInfoDelegate,
                TestConvertConstructorInfoToDependenciesTypesDelegate);
    }
}