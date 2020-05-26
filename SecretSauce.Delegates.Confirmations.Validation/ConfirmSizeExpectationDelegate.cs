using System.IO;
using SecretSauce.Delegates.Confirmations.Interfaces;

namespace SecretSauce.Delegates.Confirmations.Validation
{
    public class ConfirmSizeExpectationDelegate : IConfirmExpectationDelegate<string, long>
    {
        public bool Confirm(string uri, long expectedSize)
        {
            return new FileInfo(uri).Length == expectedSize;
        }
    }
}