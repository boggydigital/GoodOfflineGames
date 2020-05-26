using System.Collections.Generic;
using Attributes;
using SecretSauce.Delegates.Conversions.Indexes;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Storage.ProductTypes;

namespace SecretSauce.Delegates.Data.Models.ProductTypes
{
    public class DeleteUpdatedAsyncDelegate : DeleteAsyncDelegate<long>
    {
        [Dependencies(
            typeof(GetStoredListUpdatedDataAsyncDelegate),
            typeof(ConvertPassthroughIndexDelegate))]
        public DeleteUpdatedAsyncDelegate(
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