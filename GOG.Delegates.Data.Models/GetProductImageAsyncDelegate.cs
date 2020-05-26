using System.Threading.Tasks;
using Attributes;
using GOG.Models;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Network;

namespace GOG.Delegates.Data.Models
{
    public class GetProductImageAsyncDelegate : IGetDataAsyncDelegate<string, ProductFileDownloadManifest>
    {
        private readonly IGetDataToDestinationAsyncDelegate<string, string> getUriDataToDestinationAsyncDelegate;

        [Dependencies(
            typeof(GetUriDataToDestinationAsyncDelegate))]
        public GetProductImageAsyncDelegate(
            IGetDataToDestinationAsyncDelegate<string, string> getUriDataToDestinationAsyncDelegate)
        {
            this.getUriDataToDestinationAsyncDelegate = getUriDataToDestinationAsyncDelegate;
        }

        public async Task<string> GetDataAsync(ProductFileDownloadManifest productFileDownloadManifest)
        {
            if (getUriDataToDestinationAsyncDelegate != null)
                await getUriDataToDestinationAsyncDelegate.GetDataToDestinationAsyncDelegate(
                    productFileDownloadManifest.Source,
                    productFileDownloadManifest.Destination);

            return productFileDownloadManifest.Destination;
        }
    }
}