﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Interfaces.Delegates.Confirm;
using Interfaces.Delegates.Respond;
using Interfaces.Delegates.Data;
using Interfaces.Delegates.Itemize;
using Interfaces.Delegates.Activities;
using Attributes;
using GOG.Models;
using Delegates.Data.Models.ProductTypes;
using Delegates.Activities;

namespace GOG.Delegates.Respond.Update.ProductTypes
{
    [RespondsToRequests(Method = "update", Collection = "updated")]
    public class RespondToUpdateUpdatedRequestDelegate : IRespondAsyncDelegate
    {
        // private readonly IDataController<AccountProduct> accountProductDataController;
        private readonly IItemizeAllAsyncDelegate<AccountProduct> itemizeAccountProductsAsyncDelegate;
        private readonly IConfirmDelegate<AccountProduct> confirmAccountProductUpdatedDelegate;

        // private readonly IDataController<long> updatedDataController;
        private readonly IUpdateAsyncDelegate<long> updateUpdatedAsyncDelegate;
        private readonly ICommitAsyncDelegate commitUpdatedAsyncDelegate;

        private readonly IStartDelegate startDelegate;
        private readonly ISetProgressDelegate setProgressDelegate;
        private readonly ICompleteDelegate completeDelegate;

        [Dependencies(
            typeof(GOG.Delegates.Itemize.ProductTypes.ItemizeAllAccountProductsAsyncDelegate),
            typeof(GOG.Delegates.Confirm.ProductTypes.ConfirmAccountProductUpdatedDelegate),
            typeof(UpdateUpdatedAsyncDelegate),
            typeof(CommitUpdatedAsyncDelegate),
            typeof(StartDelegate),
            typeof(SetProgressDelegate),
            typeof(CompleteDelegate))]
        public RespondToUpdateUpdatedRequestDelegate(
            IItemizeAllAsyncDelegate<AccountProduct> itemizeAccountProductsAsyncDelegate,
            IConfirmDelegate<AccountProduct> confirmAccountProductUpdatedDelegate,
            IUpdateAsyncDelegate<long> updateUpdatedAsyncDelegate,
            ICommitAsyncDelegate commitUpdatedAsyncDelegate,
            IStartDelegate startDelegate,
            ISetProgressDelegate setProgressDelegate,
            ICompleteDelegate completeDelegate)
        {
            this.itemizeAccountProductsAsyncDelegate = itemizeAccountProductsAsyncDelegate;
            this.confirmAccountProductUpdatedDelegate = confirmAccountProductUpdatedDelegate;

            this.updateUpdatedAsyncDelegate = updateUpdatedAsyncDelegate;
            this.commitUpdatedAsyncDelegate = commitUpdatedAsyncDelegate;

            this.startDelegate = startDelegate;
            this.setProgressDelegate = setProgressDelegate;
            this.completeDelegate = completeDelegate;
        }

        public async Task RespondAsync(IDictionary<string, IEnumerable<string>> parameters)
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

            await foreach (var accountProduct in itemizeAccountProductsAsyncDelegate.ItemizeAllAsync())
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