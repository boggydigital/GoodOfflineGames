using System;
using Models.Extensions;

namespace SecretSauce.Delegates.Values.Filenames
{
    public class GetValidationFilenameDelegate : GetUriFilenameDelegate
    {
        public override string GetValue(string source = null)
        {
            var filename = base.GetValue(source);
            if (!filename.EndsWith(Extensions.XML, StringComparison.Ordinal))
                filename += Extensions.XML;

            return filename;
        }
    }
}