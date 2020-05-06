using System;

namespace Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class ApiEndpointAttribute : Attribute
    {
        public string Method { get; set; }
        public string Collection { get; set; }
    }
}