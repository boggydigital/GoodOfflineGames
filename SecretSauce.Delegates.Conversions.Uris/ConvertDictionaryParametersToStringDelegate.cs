using System;
using System.Collections.Generic;
using Models.Separators;
using SecretSauce.Delegates.Conversions.Interfaces;

namespace SecretSauce.Delegates.Conversions.Uris
{
    public class ConvertDictionaryParametersToStringDelegate : IConvertDelegate<IDictionary<string, string>, string>
    {
        public string Convert(IDictionary<string, string> parameters)
        {
            if (parameters == null) return string.Empty;

            var parametersStrings = new List<string>(parameters.Count);

            foreach (var key in parameters.Keys)
                parametersStrings.Add(
                    Uri.EscapeDataString(key) +
                    Separators.KeyValue +
                    Uri.EscapeDataString(parameters[key]));

            return string.Join(Separators.QueryStringParameters, parametersStrings);
        }
    }
}