using System.IO;
using System.Linq;
using Models.Extensions;
using SecretSauce.Delegates.Confirmations.Interfaces;

namespace SecretSauce.Delegates.Confirmations.Validation
{
    public class ConfirmFileValidationSupportedDelegate : IConfirmDelegate<string>
    {
        private readonly string[] extensionsWhitelist =
        {
            Extensions.EXE, // Windows
            Extensions.BIN, // Windows
            Extensions.DMG, // Mac
            Extensions.PKG, // Mac
            Extensions.SH // Linux
        };

        public bool Confirm(string uri)
        {
            var extension = Path.GetExtension(uri);
            return extensionsWhitelist.Contains(extension);
        }
    }
}