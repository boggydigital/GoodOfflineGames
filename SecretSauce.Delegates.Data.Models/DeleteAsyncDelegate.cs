using System.Collections.Generic;
using System.Threading.Tasks;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Confirmations.Interfaces;

namespace SecretSauce.Delegates.Data.Models
{
    public class DeleteAsyncDelegate<Type> : IDeleteAsyncDelegate<Type>
    {
        // private readonly IConfirmAsyncDelegate<long> confirmContainsAsyncDelegate;
        private readonly IConvertDelegate<Type, long> convertProductToIndexDelegate;
        private readonly IGetDataAsyncDelegate<List<Type>, string> getDataCollectionAsyncDelegate;

        public DeleteAsyncDelegate(
            IGetDataAsyncDelegate<List<Type>, string> getDataCollectionAsyncDelegate,
            IConvertDelegate<Type, long> convertProductToIndexDelegate)
        {
            this.getDataCollectionAsyncDelegate = getDataCollectionAsyncDelegate;
            this.convertProductToIndexDelegate = convertProductToIndexDelegate;
            // this.confirmContainsAsyncDelegate = confirmContainsAsyncDelegate;
        }

        public async Task DeleteAsync(Type deletedData)
        {
            var index = convertProductToIndexDelegate.Convert(deletedData);
            

            var data = await getDataCollectionAsyncDelegate.GetDataAsync(string.Empty);
            if (!data.Contains(deletedData)) return;
            
            data.Remove(deletedData);

            //     if (recordsController != null)
            //         await recordsController.SetRecordAsync(
            //             index,
            //             RecordsTypes.Deleted);
        }
    }
}