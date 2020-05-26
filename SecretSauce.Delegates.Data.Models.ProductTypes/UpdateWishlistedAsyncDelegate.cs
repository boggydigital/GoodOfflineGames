using System.Collections.Generic;
using Attributes;
using SecretSauce.Delegates.Conversions.Indexes;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Storage.ProductTypes;

namespace SecretSauce.Delegates.Data.Models.ProductTypes
{
    public class UpdateWishlistedAsyncDelegate : UpdateDataAsyncDelegate<long>
    {
        [Dependencies(
            typeof(DeleteWishlistedAsyncDelegate),
            typeof(ConvertPassthroughIndexDelegate),
            typeof(GetStoredListWishlistedDataAsyncDelegate))]
        public UpdateWishlistedAsyncDelegate(
            IDeleteAsyncDelegate<long> deleteWishlistedAsyncDelegate,
            IConvertDelegate<long, long> convertWishlistedToIndexDelegate,
            IGetDataAsyncDelegate<List<long>, string> getListWishlistedAsyncDelegate) :
            base(
                deleteWishlistedAsyncDelegate,
                convertWishlistedToIndexDelegate,
                getListWishlistedAsyncDelegate)
        {
            // ...
        }
    }
}