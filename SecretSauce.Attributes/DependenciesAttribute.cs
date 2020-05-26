using System;

namespace Attributes
{
    [AttributeUsage(AttributeTargets.Constructor)]
    public class DependenciesAttribute : Attribute
    {
        public DependenciesAttribute(params Type[] dependencies)
        {
            Dependencies = dependencies;
        }

        public Type[] Dependencies { get; }
    }
}