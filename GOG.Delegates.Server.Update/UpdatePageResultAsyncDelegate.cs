using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GOG.Delegates.Server.Interfaces;
using GOG.Models;
using SecretSauce.Delegates.Activities.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Itemizations.Interfaces;

namespace GOG.Delegates.Server.Update
{
    public abstract class UpdatePageResultAsyncDelegate<PageType, DataType> : IProcessAsyncDelegate
        where PageType : PageResult
    {
        private readonly ICommitAsyncDelegate commitDataAsyncDelegate;
        private readonly ICompleteDelegate completeDelegate;
        private readonly IGetDataAsyncDelegate<IList<PageType>, string> getPageResultsAsyncDelegate;
        private readonly IItemizeDelegate<IList<PageType>, DataType> itemizePageResultsDelegate;
        private readonly ISetProgressDelegate setProgressDelegate;
        private readonly IStartDelegate startDelegate;

        // private readonly IDataController<DataType> dataController;
        private readonly IUpdateAsyncDelegate<DataType> updateDataAsyncDelegate;

        public UpdatePageResultAsyncDelegate(
            IGetDataAsyncDelegate<IList<PageType>, string> getPageResultsAsyncDelegate,
            IItemizeDelegate<IList<PageType>, DataType> itemizePageResultsDelegate,
            IUpdateAsyncDelegate<DataType> updateDataAsyncDelegate,
            ICommitAsyncDelegate commitDataAsyncDelegate,
            IStartDelegate startDelegate,
            ISetProgressDelegate setProgressDelegate,
            ICompleteDelegate completeDelegate)
        {
            this.getPageResultsAsyncDelegate = getPageResultsAsyncDelegate;
            this.itemizePageResultsDelegate = itemizePageResultsDelegate;

            this.updateDataAsyncDelegate = updateDataAsyncDelegate;
            this.commitDataAsyncDelegate = commitDataAsyncDelegate;
            this.startDelegate = startDelegate;
            this.setProgressDelegate = setProgressDelegate;
            this.completeDelegate = completeDelegate;
        }

        public async Task ProcessAsync(IDictionary<string, IEnumerable<string>> parameters)
        {
            startDelegate.Start("Update products");

            var activityDescription = $"Update {typeof(DataType)}";

            var productsPageResults =
                await getPageResultsAsyncDelegate.GetDataAsync(string.Empty);

            var newProducts = itemizePageResultsDelegate.Itemize(productsPageResults);

            if (newProducts.Any())
            {
                startDelegate.Start("Save new products");

                foreach (var product in newProducts)
                {
                    setProgressDelegate.SetProgress();
                    await updateDataAsyncDelegate.UpdateAsync(product);
                }

                completeDelegate.Complete();
            }

            await commitDataAsyncDelegate.CommitAsync();

            completeDelegate.Complete();
        }
    }
}