using System.Collections.Generic;
using Models.Uris;
using SecretSauce.Delegates.Itemizations.Interfaces;

namespace GOG.Delegates.Itemizations.Throttling
{
    public class ItemizeAllRateConstrainedUrisDelegate : IItemizeAllDelegate<string>
    {
        public IEnumerable<string> ItemizeAll()
        {
            return new[]
            {
                Uris.Endpoints.Account.GameDetails, // gameDetails requests
                Uris.Endpoints.ProductFiles.ManualUrlDownlink, // manualUrls from gameDetails requests
                Uris.Endpoints.ProductFiles.ManualUrlCDNSecure, // resolved manualUrls and validation files requests
                Uris.Roots.Api // API entries
            };
        }
    }
}