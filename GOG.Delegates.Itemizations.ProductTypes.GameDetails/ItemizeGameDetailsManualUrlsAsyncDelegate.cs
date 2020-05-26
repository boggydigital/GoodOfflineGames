using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GOG.Models;
using Models.Settings;
using Models.Uris;
using SecretSauce.Delegates.Itemizations.Interfaces;

namespace GOG.Delegates.Itemizations.ProductTypes.GameDetails
{
    public class ItemizeGameDetailsManualUrlsAsyncDelegate : IItemizeAsyncDelegate<Models.GameDetails, string>
    {
        public async Task<IEnumerable<string>> ItemizeAsync(Models.GameDetails gameDetails)
        {
            // STUB - need to pass download languages and OSes
            Settings settings = null;

            if (settings == null ||
                settings.DownloadsLanguages == null ||
                settings.DownloadsOperatingSystems == null)
                throw new InvalidOperationException(
                    "Cannot enumerate game details without settings (even default).");

            var manualUrls = new List<string>();

            if (gameDetails == null) return manualUrls;

            var gameDetailsDownloadEntries = new List<DownloadEntry>();

            if (gameDetails.LanguageDownloads != null)
                foreach (var download in gameDetails.LanguageDownloads)
                {
                    if (!settings.DownloadsLanguages.Contains(download.Language)) continue;

                    if (settings.DownloadsOperatingSystems.Contains("Windows") && download.Windows != null)
                        gameDetailsDownloadEntries.AddRange(download.Windows);
                    if (settings.DownloadsOperatingSystems.Contains("Mac") && download.Mac != null)
                        gameDetailsDownloadEntries.AddRange(download.Mac);
                    if (settings.DownloadsOperatingSystems.Contains("Linux") && download.Linux != null)
                        gameDetailsDownloadEntries.AddRange(download.Linux);
                }

            if (gameDetails.Extras != null)
                gameDetailsDownloadEntries.AddRange(gameDetails.Extras);

            foreach (var downloadEntry in gameDetailsDownloadEntries)
            {
                var absoluteUri = string.Format(Uris.Endpoints.ProductFiles.ManualUrlRequestTemplate,
                    downloadEntry.ManualUrl);
                manualUrls.Add(absoluteUri);
            }

            // last but not least - recursively add DLCs
            if (gameDetails.DLCs != null)
                foreach (var dlc in gameDetails.DLCs)
                    manualUrls.AddRange(await ItemizeAsync(dlc));

            return manualUrls;
        }
    }
}