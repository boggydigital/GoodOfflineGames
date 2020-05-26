using System.Collections.Generic;
using System.Threading.Tasks;
using Attributes;
using GOG.Delegates.Data.Models.ProductTypes;
using GOG.Delegates.Server.Interfaces;
using GOG.Models;
using Models.Uris;
using SecretSauce.Delegates.Activities;
using SecretSauce.Delegates.Activities.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Models.ProductTypes;

namespace GOG.Delegates.Server.Update
{
    // TODO: This needs a refactor following GOGData deprecation
    public class UpdateWishlistedAsyncDelegate : IProcessAsyncDelegate
    {
        private readonly ICommitAsyncDelegate commitWishlistedAsyncDelegate;
        private readonly ICompleteDelegate completeDelegate;
        private readonly IStartDelegate startDelegate;
        private readonly IUpdateAsyncDelegate<long> updateWishlistedAsyncDelegate;

        [Dependencies(
            typeof(UpdateWishlistedAsyncDelegate),
            typeof(CommitWishlistedAsyncDelegate),
            typeof(StartDelegate),
            typeof(CompleteDelegate))]
        public UpdateWishlistedAsyncDelegate(
            IUpdateAsyncDelegate<long> updateWishlistedAsyncDelegate,
            ICommitAsyncDelegate commitWishlistedAsyncDelegate,
            IStartDelegate startDelegate,
            ICompleteDelegate completeDelegate)
        {
            this.updateWishlistedAsyncDelegate = updateWishlistedAsyncDelegate;
            this.commitWishlistedAsyncDelegate = commitWishlistedAsyncDelegate;
            this.startDelegate = startDelegate;
            this.completeDelegate = completeDelegate;
        }

        public async Task ProcessAsync(IDictionary<string, IEnumerable<string>> parameters)
        {
            startDelegate.Start("Update Wishlisted");

            startDelegate.Start("Request content");

            // var wishlistedProductPageResult = 
                // await getProductsPageResultDelegate.GetDataAsync(
                // Uris.Endpoints.Account.Wishlist);

            completeDelegate.Complete();

            startDelegate.Start("Save");

            // foreach (var product in wishlistedProductPageResult.Products)
            // {
            //     if (product == null) continue;
            //     await updateWishlistedAsyncDelegate.UpdateAsync(product.Id);
            // }

            completeDelegate.Complete();

            await commitWishlistedAsyncDelegate.CommitAsync();

            completeDelegate.Complete();
        }
    }
}