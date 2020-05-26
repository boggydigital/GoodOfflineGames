using System.Collections.Generic;
using System.Text.RegularExpressions;
using SecretSauce.Delegates.Itemizations.Interfaces;

namespace GOG.Delegates.Itemizations.ProductTypes.GameDetails
{
    public class ItemizeGameDetailsDownloadLanguagesDelegate : IItemizeDelegate<string, string>
    {
        public IEnumerable<string> Itemize(string data)
        {
            const string languagePattern = @"\[""[\w\\ ]*"",";
            var regex = new Regex(languagePattern);

            var match = regex.Match(data);
            while (match.Success)
            {
                yield return match.Value.Substring(1);

                match = match.NextMatch();
            }
        }
    }
}