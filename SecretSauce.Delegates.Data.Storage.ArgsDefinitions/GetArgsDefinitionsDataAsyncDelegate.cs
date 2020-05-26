using Attributes;
using Models.ArgsDefinitions;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Conversions.JSON.ArgsDefinitions;
using SecretSauce.Delegates.Data.Interfaces;

namespace SecretSauce.Delegates.Data.Storage.ArgsDefinitions
{
    public class GetArgsDefinitionsDataAsyncDelegate : GetJSONDataAsyncDelegate<ArgsDefinition>
    {
        [Dependencies(
            typeof(GetStringDataAsyncDelegate),
            typeof(ConvertJSONToArgsDefinitionDelegate))]
        public GetArgsDefinitionsDataAsyncDelegate(
            IGetDataAsyncDelegate<string, string> getStringDataAsyncDelegate,
            IConvertDelegate<string, ArgsDefinition> convertJSONToTypeDelegate) :
            base(getStringDataAsyncDelegate, convertJSONToTypeDelegate)
        {
            // ...
        }
    }
}