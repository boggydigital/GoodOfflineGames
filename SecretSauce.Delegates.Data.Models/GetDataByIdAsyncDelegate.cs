using System.Collections.Generic;
using System.Threading.Tasks;
using SecretSauce.Delegates.Collections.Interfaces;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;

namespace SecretSauce.Delegates.Data.Models
{
    public abstract class GetDataByIdAsyncDelegate<Type> : IGetDataAsyncDelegate<Type, long>
    {
        private readonly IConvertDelegate<Type, long> convertProductToIndexDelegate;
        private readonly IFindDelegate<Type> findDelegate;
        private readonly IGetDataAsyncDelegate<List<Type>, string> getDataCollectionAsyncDelegate;

        protected GetDataByIdAsyncDelegate(
            IGetDataAsyncDelegate<List<Type>, string> getDataCollectionAsyncDelegate,
            IFindDelegate<Type> findDelegate,
            IConvertDelegate<Type, long> convertProductToIndexDelegate)
        {
            this.getDataCollectionAsyncDelegate = getDataCollectionAsyncDelegate;
            this.findDelegate = findDelegate;
            this.convertProductToIndexDelegate = convertProductToIndexDelegate;
        }

        public async Task<Type> GetDataAsync(long id)
        {
            var dataCollection = await getDataCollectionAsyncDelegate.GetDataAsync(string.Empty);
            return findDelegate.Find(dataCollection, item =>
            {
                var index = convertProductToIndexDelegate.Convert(item);
                return index == id;
            });
        }
    }
}