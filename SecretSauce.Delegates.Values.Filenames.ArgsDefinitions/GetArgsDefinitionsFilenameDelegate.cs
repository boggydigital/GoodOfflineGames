using Attributes;
using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Values.Filenames.ArgsDefinitions
{
    public class GetArgsDefinitionsFilenameDelegate : GetFixedFilenameDelegate
    {
        [Dependencies(
            typeof(GetJsonFilenameDelegate))]
        public GetArgsDefinitionsFilenameDelegate(IGetValueDelegate<string, string> getJsonFilenameDelegate) :
            base(Models.Filenames.Filenames.ArgsDefinitions, getJsonFilenameDelegate)
        {
            // ...
        }
    }
}