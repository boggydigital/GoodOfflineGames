using Attributes;
using Models.ArgsDefinitions;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Values.Interfaces;
using SecretSauce.Delegates.Values.Paths.ArgsDefinitions;

namespace SecretSauce.Delegates.Data.Storage.ArgsDefinitions
{
    public class GetStoredArgsDefinitionsDataAsyncDelegate : GetStoredJSONDataAsyncDelegate<ArgsDefinition>
    {
        [Dependencies(
            typeof(GetArgsDefinitionsDataAsyncDelegate),
            typeof(GetArgsDefinitionsPathDelegate))]
        public GetStoredArgsDefinitionsDataAsyncDelegate(
            IGetDataAsyncDelegate<ArgsDefinition, string> getJSONDataAsyncDelegate,
            IGetValueDelegate<string, (string Directory, string Filename)> getPathDelegate) :
            base(getJSONDataAsyncDelegate, getPathDelegate)
        {
            // ...
        }
    }
}