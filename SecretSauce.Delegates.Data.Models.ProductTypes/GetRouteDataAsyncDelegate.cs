using System.Threading.Tasks;
using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Activities.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;

namespace SecretSauce.Delegates.Data.Models.ProductTypes
{
    public class GetRouteDataAsyncDelegate : IGetDataAsyncDelegate<string, (long Id, string Source)>
    {
        private readonly ICompleteDelegate completeDelegate;
        private readonly IGetDataAsyncDelegate<ProductRoutes, long> getProductRoutesByIdAsyncDelegate;
        private readonly IStartDelegate startDelegate;

        [Dependencies(
            typeof(GetProductRoutesByIdAsyncDelegate),
            typeof(Activities.StartDelegate),
            typeof(Activities.CompleteDelegate))]
        public GetRouteDataAsyncDelegate(
            IGetDataAsyncDelegate<ProductRoutes, long> getProductRoutesByIdAsyncDelegate,
            IStartDelegate startDelegate,
            ICompleteDelegate completeDelegate)
        {
            this.getProductRoutesByIdAsyncDelegate = getProductRoutesByIdAsyncDelegate;
            this.startDelegate = startDelegate;
            this.completeDelegate = completeDelegate;
        }

        public async Task<string> GetDataAsync((long Id, string Source) idSource)
        {
            startDelegate.Start("Trace route");

            var productRoutes = await getProductRoutesByIdAsyncDelegate.GetDataAsync(idSource.Id);

            if (productRoutes == null)
                return string.Empty;

            completeDelegate.Complete();

            if (productRoutes.Routes == null) return string.Empty;

            foreach (var route in productRoutes.Routes)
                if (route.Source == idSource.Source)
                    return route.Destination;

            return string.Empty;
        }
    }
}