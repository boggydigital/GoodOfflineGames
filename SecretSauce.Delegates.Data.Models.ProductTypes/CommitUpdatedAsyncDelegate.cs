using System.Collections.Generic;
using Attributes;
using SecretSauce.Delegates.Activities;
using SecretSauce.Delegates.Activities.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Storage.ProductTypes;

namespace SecretSauce.Delegates.Data.Models.ProductTypes
{
    public class CommitUpdatedAsyncDelegate : CommitDataAsyncDelegate<long>
    {
        [Dependencies(
            typeof(GetStoredListUpdatedDataAsyncDelegate),
            typeof(PostListUpdatedDataToPathAsyncDelegate),
            typeof(StartDelegate),
            typeof(CompleteDelegate))]
        public CommitUpdatedAsyncDelegate(
            IGetDataAsyncDelegate<List<long>, string> getDataAsyncDelegate,
            IPostDataAsyncDelegate<List<long>> postDataAsyncDelegate,
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