using System;
using System.Linq;
using System.Reflection;
using Attributes;
using GOG.Delegates.Itemizations.Types.Attributes;
using Models.Requests;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Itemizations.Interfaces;

namespace GOG.Delegates.Conversions.Requests
{
    public class ConvertRequestToProcessDelegateTypeDelegate : IConvertDelegate<Request, Type>
    {
        private readonly IItemizeAllDelegate<Type>
            itemizeAllTypesWithApiEndpointAttributeDelegate;

        [Dependencies(typeof(ItemizeAllApiEndpointAttributeTypesDelegate))]
        public ConvertRequestToProcessDelegateTypeDelegate(
            IItemizeAllDelegate<Type>
                itemizeAllTypesWithApiEndpointAttributeDelegate)
        {
            this.itemizeAllTypesWithApiEndpointAttributeDelegate = itemizeAllTypesWithApiEndpointAttributeDelegate;
        }

        public Type Convert(Request request)
        {
            return (
                from type in itemizeAllTypesWithApiEndpointAttributeDelegate.ItemizeAll()
                let apiEndpointAttribute = type.GetCustomAttribute(typeof(ApiEndpointAttribute)) as ApiEndpointAttribute
                where apiEndpointAttribute != null
                where apiEndpointAttribute.Collection == request.Collection ||
                      apiEndpointAttribute.Method == request.Method && string.IsNullOrEmpty(
                          apiEndpointAttribute.Collection) &&
                      string.IsNullOrEmpty(request.Collection)
                select type).FirstOrDefault();
        }
    }
}