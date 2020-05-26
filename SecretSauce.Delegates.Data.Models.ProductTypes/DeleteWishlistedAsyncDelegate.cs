using System.Collections.Generic;
using Attributes;
using SecretSauce.Delegates.Conversions.Indexes;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Storage.ProductTypes;

namespace SecretSauce.Delegates.Data.Models.ProductTypes
{
    public class DeleteWishlistedAsyncDelegate : DeleteAsyncDelegate<long>
    {
        [Dependencies(
            typeof(GetStoredListWishlistedDataAsyncDelegate),
            typeof(ConvertPassthroughIndexDelegate))]
        public DeleteWishlistedAsyncDelegate(
            IGetDataAsyncDelegate<List<long>, string> getDataCollectionAsyncDelegate,
            IConvertDelegate<long, long> convertProductToIndexDelegate) :
            base(
                getDataCollectionAsyncDelegate,
                convertProductToIndexDelegate)
        {
            // ...
        }
    }
}