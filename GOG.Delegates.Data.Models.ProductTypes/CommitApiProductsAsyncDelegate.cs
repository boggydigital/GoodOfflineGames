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
    public class CommitApiProductsAsyncDelegate : CommitDataAsyncDelegate<ApiProduct>
    {
        [Dependencies(
            typeof(GetStoredListApiProductDataAsyncDelegate),
            typeof(PostListApiProductDataToPathAsyncDelegate),
            typeof(StartDelegate),
            typeof(CompleteDelegate))]
        public CommitApiProductsAsyncDelegate(
            IGetDataAsyncDelegate<List<ApiProduct>, string> getDataAsyncDelegate,
            IPostDataAsyncDelegate<List<ApiProduct>> postDataAsyncDelegate,
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