using Models.Extensions;
using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Values.Filenames
{
    public class GetJsonFilenameDelegate : IGetValueDelegate<string, string>
    {
        public string GetValue(string source = null)
        {
            return source + Extensions.JSON;
        }
    }
}