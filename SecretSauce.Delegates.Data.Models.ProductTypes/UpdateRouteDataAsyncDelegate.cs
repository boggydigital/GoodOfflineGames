using System.Threading.Tasks;
using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Activities.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;

namespace SecretSauce.Delegates.Data.Models.ProductTypes
{
    public class UpdateRouteDataAsyncDelegate : IUpdateAsyncDelegate<ProductRoutes>
    {
        private readonly ICommitAsyncDelegate commitProductRoutesAsyncDelegate;
        private readonly ICompleteDelegate completeDelegate;
        private readonly IGetDataAsyncDelegate<ProductRoutes, long> getProductRoutesByIdAsyncDelegate;
        private readonly IStartDelegate startDelegate;
        private readonly IUpdateAsyncDelegate<ProductRoutes> updateProductRoutesAsyncDelegate;

        [Dependencies(
            typeof(GetProductRoutesByIdAsyncDelegate),
            typeof(UpdateProductRoutesAsyncDelegate),
            typeof(CommitProductRoutesAsyncDelegate),
            typeof(Activities.StartDelegate),
            typeof(Activities.CompleteDelegate))]
        public UpdateRouteDataAsyncDelegate(
            IGetDataAsyncDelegate<ProductRoutes, long> getProductRoutesByIdAsyncDelegate,
            IUpdateAsyncDelegate<ProductRoutes> updateProductRoutesAsyncDelegate,
            ICommitAsyncDelegate commitProductRoutesAsyncDelegate,
            IStartDelegate startDelegate,
            ICompleteDelegate completeDelegate)
        {
            this.getProductRoutesByIdAsyncDelegate = getProductRoutesByIdAsyncDelegate;
            this.updateProductRoutesAsyncDelegate = updateProductRoutesAsyncDelegate;
            this.commitProductRoutesAsyncDelegate = commitProductRoutesAsyncDelegate;
            this.startDelegate = startDelegate;
            this.completeDelegate = completeDelegate;
        }

        public async Task UpdateAsync(ProductRoutes newProductRoute)
        {
            // TODO: I patched this together for controller->delegate deprecation, but this should be rewritten
            // probably using something like Associate delegate model where I'd associate two values together (manualUrl and resolvedUri)
            startDelegate.Start("Update route");

            var existingProductRoutes = await getProductRoutesByIdAsyncDelegate.GetDataAsync(newProductRoute.Id);

            var existingRouteUpdated = false;
            foreach (var newRoute in newProductRoute.Routes)
            foreach (var route in existingProductRoutes.Routes)
                if (route.Source == newRoute.Source)
                {
                    route.Destination = newRoute.Destination;
                    existingRouteUpdated = true;
                    break;
                }

            if (!existingRouteUpdated)
                foreach (var newRoute in newProductRoute.Routes)
                    existingProductRoutes.Routes.Add(new ProductRoutesEntry
                    {
                        Source = newRoute.Source,
                        Destination = newRoute.Destination
                    });

            await updateProductRoutesAsyncDelegate.UpdateAsync(existingProductRoutes);

            await commitProductRoutesAsyncDelegate.CommitAsync();

            completeDelegate.Complete();
        }
    }
}