using System.Collections.Generic;
using Attributes;
using GOG.Delegates.Data.Storage.ProductTypes;
using GOG.Models;
using SecretSauce.Delegates.Activities;
using SecretSauce.Delegates.Activities.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Models;

namespace GOG.Delegates.Data.Models.ProductTypes
{
    public class CommitAccountProductsAsyncDelegate : CommitDataAsyncDelegate<AccountProduct>
    {
        [Dependencies(
            typeof(GetStoredListAccountProductDataAsyncDelegate),
            typeof(PostListAccountProductDataToPathAsyncDelegate),
            typeof(StartDelegate),
            typeof(CompleteDelegate))]
        public CommitAccountProductsAsyncDelegate(
            IGetDataAsyncDelegate<List<AccountProduct>, string> getDataAsyncDelegate,
            IPostDataAsyncDelegate<List<AccountProduct>> postDataAsyncDelegate,
            IStartDelegate startDelegate,
            ICompleteDelegate completeDelegate) :
            base(
                getDataAsyncDelegate,
                postDataAsyncDelegate,
                startDelegate,
                completeDelegate)
        {
            // ...
        }
    }
}