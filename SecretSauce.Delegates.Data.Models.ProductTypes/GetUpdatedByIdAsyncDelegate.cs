using System.Collections.Generic;
using Attributes;
using SecretSauce.Delegates.Collections.Interfaces;
using SecretSauce.Delegates.Conversions;
using SecretSauce.Delegates.Conversions.Indexes;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Storage.ProductTypes;

namespace SecretSauce.Delegates.Data.Models.ProductTypes
{
    public class GetUpdatedByIdAsyncDelegate :
        GetDataByIdAsyncDelegate<long>
    {
        [Dependencies(
            typeof(GetStoredListUpdatedDataAsyncDelegate),
            typeof(Delegates.Collections.ProductTypes.FindUpdatedDelegate),
            typeof(ConvertPassthroughIndexDelegate))]
        public GetUpdatedByIdAsyncDelegate(
            IGetDataAsyncDelegate<List<long>, string> getDataCollectionAsyncDelegate,
            IFindDelegate<long> findDelegate,
            IConvertDelegate<long, long> convertProductToIndexDelegate) :
            base(
                getDataCollectionAsyncDelegate,
                findDelegate,
                convertProductToIndexDelegate)
        {
            // ...
        }
    }
}