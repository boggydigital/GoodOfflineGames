using System.Collections.Generic;
using Delegates.Data.Models;
using GOG.Models;
using Interfaces.Delegates.Activities;
using Interfaces.Delegates.Data;
using Attributes;
using Delegates.Activities;

namespace GOG.Delegates.Data.Models.ProductTypes
{
    public class CommitProductsAsyncDelegate : CommitDataAsyncDelegate<Product>
    {
        [Dependencies(
            typeof(GOG.Delegates.Data.Storage.ProductTypes.GetStoredListProductDataAsyncDelegate),
            typeof(GOG.Delegates.Data.Storage.ProductTypes.PostListProductDataToPathAsyncDelegate),
            typeof(StartDelegate),
            typeof(CompleteDelegate))]
        public CommitProductsAsyncDelegate(
            IGetDataAsyncDelegate<List<Product>, string> getDataAsyncDelegate,
            IPostDataAsyncDelegate<List<Product>> postDataAsyncDelegate,
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