using System.Collections.Generic;
using Attributes;
using GOG.Models;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Storage;
using SecretSauce.Delegates.Values.Interfaces;
using SecretSauce.Delegates.Values.Paths.ProductTypes;

namespace GOG.Delegates.Data.Storage.ProductTypes
{
    public class PostListGameDetailsDataToPathAsyncDelegate : PostJSONDataToPathAsyncDelegate<List<GameDetails>>
    {
        [Dependencies(
            typeof(PostListGameDetailsDataAsyncDelegate),
            typeof(GetGameDetailsPathDelegate))]
        public PostListGameDetailsDataToPathAsyncDelegate(
            IPostDataAsyncDelegate<List<GameDetails>> postListGameDetailsDataAsyncDelegate,
            IGetValueDelegate<string, (string Directory, string Filename)> getGameDetailsPathDelegate) :
            base(
                postListGameDetailsDataAsyncDelegate,
                getGameDetailsPathDelegate)
        {
            // ...
        }
    }
}