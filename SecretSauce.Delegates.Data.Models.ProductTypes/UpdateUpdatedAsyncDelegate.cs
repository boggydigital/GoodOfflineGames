using System.Collections.Generic;
using Attributes;
using SecretSauce.Delegates.Conversions.Indexes;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Storage.ProductTypes;

namespace SecretSauce.Delegates.Data.Models.ProductTypes
{
    public class UpdateUpdatedAsyncDelegate : UpdateDataAsyncDelegate<long>
    {
        [Dependencies(
            typeof(DeleteUpdatedAsyncDelegate),
            typeof(ConvertPassthroughIndexDelegate),
            typeof(GetStoredListUpdatedDataAsyncDelegate))]
        public UpdateUpdatedAsyncDelegate(
            IDeleteAsyncDelegate<long> deleteUpdatedAsyncDelegate,
            IConvertDelegate<long, long> convertUpdatedToIndexDelegate,
            IGetDataAsyncDelegate<List<long>, string> getListUpdatedAsyncDelegate) :
            base(
                deleteUpdatedAsyncDelegate,
                convertUpdatedToIndexDelegate,
                getListUpdatedAsyncDelegate)
        {
            // ...
        }
    }
}