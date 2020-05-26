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
    public class CommitGameDetailsAsyncDelegate : CommitDataAsyncDelegate<GameDetails>
    {
        [Dependencies(
            typeof(GetStoredListGameDetailsDataAsyncDelegate),
            typeof(PostListGameDetailsDataToPathAsyncDelegate),
            typeof(StartDelegate),
            typeof(CompleteDelegate))]
        public CommitGameDetailsAsyncDelegate(
            IGetDataAsyncDelegate<List<GameDetails>, string> getDataAsyncDelegate,
            IPostDataAsyncDelegate<List<GameDetails>> postDataAsyncDelegate,
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