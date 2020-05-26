using System.Collections.Generic;
using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Activities;
using SecretSauce.Delegates.Activities.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Storage.ProductTypes;

namespace SecretSauce.Delegates.Data.Models.ProductTypes
{
    public class CommitProductDownloadsAsyncDelegate : CommitDataAsyncDelegate<ProductDownloads>
    {
        [Dependencies(
            typeof(GetStoredListProductDownloadsDataAsyncDelegate),
            typeof(PostListProductDownloadsDataToPathAsyncDelegate),
            typeof(StartDelegate),
            typeof(CompleteDelegate))]
        public CommitProductDownloadsAsyncDelegate(
            IGetDataAsyncDelegate<List<ProductDownloads>, string> getDataAsyncDelegate,
            IPostDataAsyncDelegate<List<ProductDownloads>> postDataAsyncDelegate,
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