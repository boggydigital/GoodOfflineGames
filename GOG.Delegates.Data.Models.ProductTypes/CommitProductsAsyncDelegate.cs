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
    public class CommitProductsAsyncDelegate : CommitDataAsyncDelegate<Product>
    {
        [Dependencies(
            typeof(GetStoredListProductDataAsyncDelegate),
            typeof(PostListProductDataToPathAsyncDelegate),
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