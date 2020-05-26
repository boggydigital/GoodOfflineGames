using System.Collections.Generic;
using Attributes;
using SecretSauce.Delegates.Activities.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Storage.ProductTypes;

namespace SecretSauce.Delegates.Data.Models.ProductTypes
{
    public class CommitWishlistedAsyncDelegate : CommitDataAsyncDelegate<long>
    {
        [Dependencies(
            typeof(GetStoredListWishlistedDataAsyncDelegate),
            typeof(PostListWishlistedDataToPathAsyncDelegate),
            typeof(Activities.StartDelegate),
            typeof(Activities.CompleteDelegate))]
        public CommitWishlistedAsyncDelegate(
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