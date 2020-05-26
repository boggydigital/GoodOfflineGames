using System.Collections.Generic;
using Attributes;
using Models.Requests;
using SecretSauce.Delegates.Conversions.Interfaces;

namespace SecretSauce.Delegates.Conversions.Requests
{
    public class ConvertRequestToStringDelegate :
        IConvertDelegate<Request, string>
    {
        private readonly IConvertDelegate<IDictionary<string, IEnumerable<string>>, string>
            convertParametersToStringDelegate;

        [Dependencies(
            typeof(ConvertParametersToStringDelegate))]
        public ConvertRequestToStringDelegate(
            IConvertDelegate<IDictionary<string, IEnumerable<string>>, string> convertParametersToStringDelegate)
        {
            this.convertParametersToStringDelegate = convertParametersToStringDelegate;
        }

        public string Convert(Request request)
        {
            return
                $"{request.Method.ToUpper()} /{request.Collection}{convertParametersToStringDelegate.Convert(request.Parameters)}";
        }
    }
}