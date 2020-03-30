using System.Collections.Generic;

using Interfaces.Delegates.Convert;

using Models.Separators;

namespace Delegates.Convert.Uri
{
    public class ConvertDictionaryParametersToStringDelegate : IConvertDelegate<IDictionary<string, string>, string>
    {
        public string Convert(IDictionary<string, string> parameters)
        {
            if (parameters == null) return string.Empty;

            var parametersStrings = new List<string>(parameters.Count);

            foreach (string key in parameters.Keys)
            {
                parametersStrings.Add(
                    System.Uri.EscapeDataString(key) +
                    Separators.KeyValue +
                    System.Uri.EscapeDataString(parameters[key]));
            }

            return string.Join(Separators.QueryStringParameters, parametersStrings);
        }
    }
}