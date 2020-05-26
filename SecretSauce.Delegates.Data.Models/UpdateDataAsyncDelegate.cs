using System.Collections.Generic;
using System.Threading.Tasks;
using Interfaces.Models.RecordTypes;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;

namespace SecretSauce.Delegates.Data.Models
{
    public class UpdateDataAsyncDelegate<Type> : IUpdateAsyncDelegate<Type>
    {
        private readonly IConvertDelegate<Type, long> convertProductToIndexDelegate;
        private readonly IDeleteAsyncDelegate<Type> deleteAsyncDelegate;
        private readonly IGetDataAsyncDelegate<List<Type>, string> getDataCollectionAsyncDelegate;

        public UpdateDataAsyncDelegate(
            IDeleteAsyncDelegate<Type> deleteAsyncDelegate,
            IConvertDelegate<Type, long> convertProductToIndexDelegate,
            IGetDataAsyncDelegate<List<Type>, string> getDataCollectionAsyncDelegate)
        {
            this.deleteAsyncDelegate = deleteAsyncDelegate;
            this.convertProductToIndexDelegate = convertProductToIndexDelegate;
            this.getDataCollectionAsyncDelegate = getDataCollectionAsyncDelegate;
        }

        public async Task UpdateAsync(Type updatedData)
        {
            var updatedDataId = convertProductToIndexDelegate.Convert(updatedData);
            var recordType = RecordsTypes.Created;

            var data = await getDataCollectionAsyncDelegate.GetDataAsync(string.Empty);
            if (data.Contains(updatedData))
            {
                await deleteAsyncDelegate.DeleteAsync(updatedData);
                recordType = RecordsTypes.Updated;
            }

            data.Add(updatedData);

            // if (recordsController != null)
            //     await recordsController.SetRecordAsync(
            //         updatedDataId,
            //         recordType);
        }
    }
}