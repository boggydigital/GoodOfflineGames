using System.Collections.Generic;
using System.Threading.Tasks;
using Attributes;
using GOG.Delegates.Confirmations.ProductTypes;
using GOG.Delegates.Data.Storage.ProductTypes;
using GOG.Delegates.Itemizations.ProductTypes;
using GOG.Delegates.Server.Interfaces;
using GOG.Models;
using SecretSauce.Delegates.Activities;
using SecretSauce.Delegates.Activities.Interfaces;
using SecretSauce.Delegates.Confirmations.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Models.ProductTypes;
using SecretSauce.Delegates.Itemizations.Interfaces;

namespace GOG.Delegates.Server.Update
{
    [ApiEndpoint(Method = "update", Collection = "updated")]
    public class UpdateUpdatedAsyncDelegate : IProcessAsyncDelegate
    {
        private readonly ICommitAsyncDelegate commitUpdatedAsyncDelegate;
        private readonly ICompleteDelegate completeDelegate;

        private readonly IConfirmDelegate<AccountProduct> confirmAccountProductUpdatedDelegate;

        // private readonly IDataController<AccountProduct> accountProductDataController;
        private readonly IGetDataAsyncDelegate<IList<AccountProduct>, string> getAccountProductsAsyncDelegate;
        private readonly ISetProgressDelegate setProgressDelegate;

        private readonly IStartDelegate startDelegate;

        // private readonly IDataController<long> updatedDataController;
        private readonly IUpdateAsyncDelegate<long> updateUpdatedAsyncDelegate;

        [Dependencies(
            typeof(GetStoredListAccountProductDataAsyncDelegate),
            typeof(ConfirmAccountProductUpdatedDelegate),
            typeof(UpdateUpdatedAsyncDelegate),
            typeof(CommitUpdatedAsyncDelegate),
            typeof(StartDelegate),
            typeof(SetProgressDelegate),
            typeof(CompleteDelegate))]
        public UpdateUpdatedAsyncDelegate(
            IGetDataAsyncDelegate<IList<AccountProduct>, string> getAccountProductsAsyncDelegate,
            IConfirmDelegate<AccountProduct> confirmAccountProductUpdatedDelegate,
            IUpdateAsyncDelegate<long> updateUpdatedAsyncDelegate,
            ICommitAsyncDelegate commitUpdatedAsyncDelegate,
            IStartDelegate startDelegate,
            ISetProgressDelegate setProgressDelegate,
            ICompleteDelegate completeDelegate)
        {
            this.getAccountProductsAsyncDelegate = getAccountProductsAsyncDelegate;
            this.confirmAccountProductUpdatedDelegate = confirmAccountProductUpdatedDelegate;

            this.updateUpdatedAsyncDelegate = updateUpdatedAsyncDelegate;
            this.commitUpdatedAsyncDelegate = commitUpdatedAsyncDelegate;

            this.startDelegate = startDelegate;
            this.setProgressDelegate = setProgressDelegate;
            this.completeDelegate = completeDelegate;
        }

        public async Task ProcessAsync(IDictionary<string, IEnumerable<string>> parameters)
        {
            // This activity will centralize processing and marking updated account products.
            // Currently the process is the following:
            // 1) Itemize account products that were created after last updateData-accountProducts
            // Please note, that every updateData-accountProducts that results in new products will 
            // overwrite this timestamp, so it's expected that updateData-updated is run between the 
            // sessions that produce new account products.
            // 2) Itemize all account products and confirm is isNew or Updates passes the condition
            // ...
            // In the future additional heuristics can be employed - such as using products, not just 
            // account products and other. Currently they are considered as YAGNI

            startDelegate.Start("Process updated account products");

            startDelegate.Start("Add account products created since last data update");

            var accountProductsNewOrUpdated = new List<long>();

            //var lastUpdatedAccountProductsData = await activityContextCreatedIndexController.GetCreatedAsync(
            //    activityContextController.ToString((A.UpdateData, Context.AccountProducts)), addNewlyCreatedStatus);

            //var newlyCreatedAccountProducts = await accountProductDataController.ItemizeAsync(lastUpdatedAccountProductsData, addNewlyCreatedStatus);

            //accountProductsNewOrUpdated.AddRange(newlyCreatedAccountProducts);

            completeDelegate.Complete();

            startDelegate.Start("Add updated account products");

            foreach (var accountProduct in await getAccountProductsAsyncDelegate.GetDataAsync(string.Empty))
            {
                setProgressDelegate.SetProgress();

                if (confirmAccountProductUpdatedDelegate.Confirm(accountProduct))
                    accountProductsNewOrUpdated.Add(accountProduct.Id);
            }

            foreach (var accountProduct in accountProductsNewOrUpdated)
                await updateUpdatedAsyncDelegate.UpdateAsync(accountProduct);

            completeDelegate.Complete();

            await commitUpdatedAsyncDelegate.CommitAsync();

            completeDelegate.Complete();
        }
    }
}