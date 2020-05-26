using System;
using System.Collections.Generic;
using Models.Separators;
using SecretSauce.Delegates.Itemizations.Interfaces;

namespace GOG.Delegates.Itemizations.ProductTypes.GameDetails
{
    public class ItemizeGameDetailsDownloadsDelegate : IItemizeDelegate<string, string>
    {
        public IEnumerable<string> Itemize(string data)
        {
            // downloads are double array and so far nothing else in the game details data is
            // so we'll leverage this fact to extract actual content

            var result = string.Empty;

            int fromIndex = data.IndexOf(Separators.GameDetailsDownloadsStart, StringComparison.Ordinal),
                toIndex = data.IndexOf(Separators.GameDetailsDownloadsEnd, StringComparison.Ordinal);

            if (fromIndex < toIndex)
                result = data.Substring(
                    fromIndex,
                    toIndex - fromIndex + Separators.GameDetailsDownloadsEnd.Length);

            return new[] {result};
        }
    }
}