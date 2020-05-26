using Attributes;
using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Values.Filenames.JSON
{
    public class GetCookiesFilenameDelegate : GetFixedFilenameDelegate
    {
        [Dependencies(
            typeof(GetJsonFilenameDelegate))]
        public GetCookiesFilenameDelegate(IGetValueDelegate<string, string> getJsonFilenameDelegate) :
            base(Models.Filenames.Filenames.Cookies, getJsonFilenameDelegate)
        {
            // ...
        }
    }
}