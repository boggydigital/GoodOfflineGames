using System.IO;
using SecretSauce.Delegates.Confirmations.Interfaces;

namespace SecretSauce.Delegates.Confirmations.Validation
{
    public class ConfirmFilenameExpectationDelegate : IConfirmExpectationDelegate<string, string>
    {
        public bool Confirm(string uri, string expectedFilename)
        {
            return Path.GetFileName(uri) == expectedFilename;
        }
    }
}