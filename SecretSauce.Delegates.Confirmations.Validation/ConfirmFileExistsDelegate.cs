using System.IO;
using SecretSauce.Delegates.Confirmations.Interfaces;

namespace SecretSauce.Delegates.Confirmations.Validation
{
    public class ConfirmFileExistsDelegate : IConfirmDelegate<string>
    {
        public bool Confirm(string validationFileUri)
        {
            return File.Exists(validationFileUri);
        }
    }
}