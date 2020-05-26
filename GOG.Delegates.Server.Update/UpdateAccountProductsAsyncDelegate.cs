using System.Collections.Generic;
using Attributes;
using GOG.Delegates.Data.Models.ProductTypes;
using GOG.Delegates.Itemizations;
using GOG.Delegates.Itemizations.ProductTypes;
using GOG.Models;
using SecretSauce.Delegates.Activities;
using SecretSauce.Delegates.Activities.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Itemizations.Interfaces;

namespace GOG.Delegates.Server.Update
{
    // TODO: We should generate those files
    [ApiEndpoint(Method = "update", Collection = "accountproducts")]
    public class UpdateAccountProductsAsyncDelegate :
        UpdatePageResultAsyncDelegate<AccountProductsPageResult, AccountProduct>
    {
        [Dependencies(
            typeof(GetAccountProductsPageResultsAsyncDelegate),
            typeof(ItemizeAccountProductsPageResultProductsDelegate),
            typeof(UpdateAccountProductsAsyncDelegate),
            typeof(CommitAccountProductsAsyncDelegate),
            typeof(StartDelegate),
            typeof(SetProgressDelegate),
            typeof(CompleteDelegate))]
        public UpdateAccountProductsAsyncDelegate(
            IGetDataAsyncDelegate<IList<AccountProductsPageResult>, string>
                getAccountProductsPageResultsAsyncDelegate,
            IItemizeDelegate<IList<AccountProductsPageResult>, AccountProduct>
                itemizeAccountProductsPageResultsDelegate,
            IUpdateAsyncDelegate<AccountProduct> updateAccountProductsAsyncDelegate,
            ICommitAsyncDelegate commitAccountProductsAsyncDelegate,
            IStartDelegate startDelegate,
            ISetProgressDelegate setProgressDelegate,
            ICompleteDelegate completeDelegate) :
            base(
                getAccountProductsPageResultsAsyncDelegate,
                itemizeAccountProductsPageResultsDelegate,
                updateAccountProductsAsyncDelegate,
                commitAccountProductsAsyncDelegate,
                startDelegate,
                setProgressDelegate,
                completeDelegate)
        {
            // ...
        }
    }
}