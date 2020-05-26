using System.Collections.Generic;
using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Activities.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Storage.ProductTypes;

namespace SecretSauce.Delegates.Data.Models.ProductTypes
{
    public class CommitProductRoutesAsyncDelegate : CommitDataAsyncDelegate<ProductRoutes>
    {
        [Dependencies(
            typeof(GetStoredListProductRoutesDataAsyncDelegate),
            typeof(PostListProductRoutesDataToPathAsyncDelegate),
            typeof(Activities.StartDelegate),
            typeof(Activities.CompleteDelegate))]
        public CommitProductRoutesAsyncDelegate(
            IGetDataAsyncDelegate<List<ProductRoutes>, string> getDataAsyncDelegate,
            IPostDataAsyncDelegate<List<ProductRoutes>> postDataAsyncDelegate,
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