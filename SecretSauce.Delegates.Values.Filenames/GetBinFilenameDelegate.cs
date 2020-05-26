using SecretSauce.Delegates.Values.Interfaces;
using Extensions = Models.Extensions.Extensions;

namespace SecretSauce.Delegates.Values.Filenames
{
    public class GetBinFilenameDelegate : IGetValueDelegate<string, string>
    {
        public string GetValue(string source = null)
        {
            return source + Extensions.BIN;
        }
    }
}